using UnityEngine;
using System.Collections;

public class MeleeAttackController : MonoBehaviour {

	public bool canAttack = true;
	
	private Animator animator;
	
	/////////////////////
	/// Unity Functions
	/////////////////////
	
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	void FixedUpdate () {
		Attack();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			HedgeController hc = other.gameObject.GetComponent<HedgeController>();
			hc.DecreaseState();
		}
	}
	
	/////////////////////
	/// Our Functions
	/////////////////////
	
	void Attack() {
		if (Input.GetAxisRaw ("Fire1") != 0 && canAttack) {
			animator.SetBool("Attack", true);
		}
	}
	
	void TurnOffAttackCollider() {
		gameObject.GetComponents<BoxCollider2D>()[1].enabled = false;
		canAttack = true;
		animator.SetBool ("Attack", false);
	}
	
	void TurnOnAttackCollider() {
		gameObject.GetComponents<BoxCollider2D>()[1].enabled = true;
	}
	
	
}
