using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

	public float bulletSpeed = 10f;
	public bool facingRight = true;
	
	// Use this for initialization
	void Start () {
		if (facingRight) {
			rigidbody2D.velocity = Vector2.right * bulletSpeed;
		}
		else {
			rigidbody2D.velocity = -Vector2.right * bulletSpeed;
		}

		Destroy (gameObject, 2.0f);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		//if (other.gameObject.tag != "Player") {
		//	GameObject.Destroy (gameObject);
		//}
		
		if (other.gameObject.tag != "Enemy") 
		{
			Destroy (gameObject);
		}
	}
}