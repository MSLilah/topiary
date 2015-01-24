using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

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
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag != "Player") {
			Debug.Log ("Collision!");
			GameObject.Destroy (gameObject);
		}
	}
}
