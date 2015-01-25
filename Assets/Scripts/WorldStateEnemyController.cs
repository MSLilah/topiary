using UnityEngine;
using System.Collections;

public class WorldStateEnemyController : MonoBehaviour {

	private Animator animator;
	
	void Start() {
		animator = GetComponent<Animator>();
		animator.SetBool ("LightWorld", true);
	}

	public void WorldStateChange(bool lightWorld) {
		HedgeController hc = GetComponent<HedgeController>();
		EnemyController ec = GetComponent<EnemyController>();
		if (lightWorld) {
			hc.enabled = true;
			ec.enabled = false;
			renderer.enabled = true;
			rigidbody2D.isKinematic = true;
			animator.SetBool ("LightWorld", true);
			//GetComponents<BoxCollider2D>()[1].enabled = false;
			if (ec.enemyHealth <= 0.0f) {
				hc.SetState(HedgeController.HedgeState.OVERGROWN);
			}
			else {
				hc.SetState (HedgeController.HedgeState.TRIMMED);
			}
		}
		else {
			hc.enabled = false;
			ec.enabled = true;
			rigidbody2D.isKinematic = false;
			collider2D.enabled = true;
			animator.SetBool ("LightWorld", false);
			//GetComponents<BoxCollider2D>()[1].enabled = true;
			if (hc.state == HedgeController.HedgeState.OVERGROWN) {
				ec.enemyHealth = 0.0f;
			}
			else {
				ec.enemyHealth = 3.0f;
			}
		}
	}
}
 