using UnityEngine;
using System.Collections;

public class WorldStateEnemyController : MonoBehaviour {

	public void WorldStateChange(bool lightWorld) {
		HedgeController hc = GetComponent<HedgeController>();
		EnemyController ec = GetComponent<EnemyController>();
		if (lightWorld) {
			hc.enabled = true;
			ec.enabled = false;
			renderer.enabled = true;
			collider2D.enabled = true;
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
			if (hc.state == HedgeController.HedgeState.OVERGROWN) {
				ec.enemyHealth = 3.0f;
			}
			else {
				ec.enemyHealth = 0.0f;
			}
		}
	}
}
