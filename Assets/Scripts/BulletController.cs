using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float bulletSpeed = 10f;
	public bool facingRight = true;

	private float lifeTimer = 0.0f;
	public float maxLifeTime = 3.0f;

	// Use this for initialization
	void Start () {
		if (facingRight) {
			rigidbody2D.velocity = Vector2.right * bulletSpeed;
		}
		else {
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
			rigidbody2D.velocity = -Vector2.right * bulletSpeed;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag != "Player") {
			GameObject.Destroy (gameObject);
		}
	}

	void Update() {
		lifeTimer += Time.deltaTime;
		if (lifeTimer >= maxLifeTime) {
			GameObject.Destroy (gameObject);
		}
	}
	
}
