using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	
	public GameObject bullet;
	public Transform bulletSpawner;
	private float shotTimer = 1.0f;


	private float walkSpeed = 2.0f;
	private float walkingDirection = 1.0f;
	public  bool walkingRight = true;
	private bool facingRight = false;

	public float enemyHealth = 1.0f;
	private AudioSource dieAudio;


	Vector2 walkAmount;
	
	void Start ()
	{
		walkingDirection = 1.0f;
		Flip ();
		AudioSource[] audios = GetComponents<AudioSource>();
		dieAudio = audios [0];
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "EdgeRight") 
		{
			walkingDirection = -1.0f;
			walkingRight = false;
			Flip ();
		} 
		else if (col.gameObject.tag == "EdgeLeft") 
		{
			walkingDirection = 1.0f;
			walkingRight = true;
			Flip ();
		} 
		else if (col.gameObject.tag == "Bullet") 
		{
			enemyHealth--;
			Debug.Log ("Took damage!");
			if (enemyHealth <= 0.0f) {
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().IncreaseScore();
			}
		}
	}

	void Update () 
	{
		if (enemyHealth > 0) {
			EnemyMovement ();
			ShootBullet ();
		}
		HandleDeath ();
	}

	void EnemyMovement ()
	{
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		
		transform.Translate (walkAmount);
	}

	
	void ShootBullet ()
	{
		shotTimer += Time.deltaTime;

		if (shotTimer >= 1.5f) 
		{
			GameObject newBullet = Instantiate(bullet, bulletSpawner.position, Quaternion.identity) as GameObject;
			newBullet.GetComponent<EnemyBulletController>().facingRight = facingRight;
			shotTimer = 0.0f;
		}
	}

	void HandleDeath () 
	{
		//Stop rendering the enemy and disable this script if
		//the enemy is dead
		if (enemyHealth <= 0) 
		{
			renderer.enabled = false;
			collider2D.enabled = false;
			rigidbody2D.isKinematic = true;
			enabled = false;
			dieAudio.Play();
		}
	}
	
	void Flip() {
		facingRight = !facingRight;
		
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
