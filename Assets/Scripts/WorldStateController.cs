using UnityEngine;
using System.Collections;

public class WorldStateController : MonoBehaviour {

	private bool lightWorld = true;
	private float timer = 0.0f;
	private float timerLife;
	
	public float minTime = 5.0f;
	public float maxTime = 15.0f;
	private bool switchTrigger = true;
	
	void Start() {
		//ChangeWorldState ();
	}
	
	void Update() {
		
		if (switchTrigger) {
			timer += Time.deltaTime;
			if (timer > 2.0f) {
				Debug.Log ("Changing World State");
				ChangeWorldState();
				timer = 0.0f;
				timerLife = Random.Range (minTime, maxTime);
			}
		}
	}
	
	void OnTriggerEnter2D() {
		if (!switchTrigger) {
			switchTrigger = true;
			ChangeWorldState ();
			timerLife = Random.Range (minTime, maxTime);
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
