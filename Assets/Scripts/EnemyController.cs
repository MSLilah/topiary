using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	
	public GameObject bullet;
	public Transform bulletSpawner;
	private float shotTimer = 1.0f;


	private float walkSpeed = 2.0f;
	private float walkingDirection = 1.0f;
	public  bool walkingRight = true;
	private bool facingRight = true;

	private float enemyHealth = 3.0f;


	Vector2 walkAmount;
	
	void Start ()
	{
		walkingDirection = 1.0f;
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
		}
	}

	void Update () 
	{
		EnemyMovement ();
		ShootBullet ();
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
		if (enemyHealth <= 0) 
		{
			Destroy (gameObject);
		}
	}
	void Flip() {
		facingRight = !facingRight;
	}
}
