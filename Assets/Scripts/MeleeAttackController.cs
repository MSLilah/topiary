using UnityEngine;
using System.Collections;

public class MeleeAttackController : MonoBehaviour {

	public bool canAttack = true;
	private AudioSource sliceAudio;

	private Animator animator;
	
	/////////////////////
	/// Unity Functions
	/////////////////////
	
	void Start () {
		animator = GetComponent<Animator> ();
		AudioSource[] audios = GetComponents<AudioSource>();
		sliceAudio = audios [1];
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
			canAttack = false;
			animator.SetBool("Attack", true);
			sliceAudio.PlayDelayed(0.4f);
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
