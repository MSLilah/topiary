using UnityEngine;
using System.Collections;

public class WorldStateController : MonoBehaviour {

	private bool lightWorld = true;
	private float timer = 0.0f;
	
	void Update() {
		timer += Time.deltaTime;
		if (timer > 2.0f) {
			Debug.Log ("Changing World State");
			ChangeWorldState();
			timer = 0.0f;
		}
	}
	
	public void ChangeWorldState() {
		lightWorld = !lightWorld;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		
		player.GetComponent<PlayerController>().WorldStateChange(lightWorld);
		
		foreach (GameObject enemy in enemies) {
			enemy.GetComponent<WorldStateEnemyController>().WorldStateChange(lightWorld);
		}
	}
}
