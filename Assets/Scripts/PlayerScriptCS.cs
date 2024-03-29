﻿using UnityEngine;
using System.Collections;

public class PlayerScriptCS : MonoBehaviour {
	
	
	//Player health and damage
	private float playerHealth = 5.0f;
	private float playerInvulTime;
	private bool isDamaged;
	private float knockbackDir;
	private float enemyX;
	private float playerX;
	
	
	[SerializeField] private Transform spawnPoint;
	private GameObject SpawnPoint;
	
	public GUIStyle style;
	
	void Start ()
	{
		SpawnPoint = GameObject.Find ("SpawnPoint");
		spawnPoint = SpawnPoint.transform;
		
		// Reset starting position to the spawn point
		gameObject.transform.position = spawnPoint.position;
	}
	
	void Update ()
	{
		HandleDamage ();
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (GetComponent<GunController> ().enabled == true) 
		{
			
			if (col.gameObject.tag == "Enemy" && !isDamaged && col.gameObject.renderer.enabled) 
			{
				playerHealth--;
				
				Debug.Log ("Take damage!");
				
				enemyX = col.transform.position.x;
				playerX = gameObject.transform.position.x;
				
				if (enemyX < playerX) 
				{
					rigidbody2D.AddForce (Vector3.right * 150);
				} 
				
				else if (enemyX > playerX) 
				{
					rigidbody2D.AddForce (Vector3.left * 150);
				}
				
				isDamaged = true;
				
			}
		}
		
		if (col.gameObject.tag == "BossWhip" && !isDamaged) 
		{
			Debug.Log ("Whipped!");
			playerHealth--;
			isDamaged = true;
		}
		
		if (col.gameObject.tag == "Hazard" && !isDamaged) 
		{
			Debug.Log ("Thorns!");
			playerHealth--;
			isDamaged = true;
		}
		
	}
	
	void HandleDamage ()
	{
		if (isDamaged == true && playerHealth >= 1) 
		{
			playerInvulTime += Time.deltaTime;
			
			if (playerInvulTime >= 1.5f) 
			{
				isDamaged = false;
				playerInvulTime = 0.0f;
			}
			
		} 
		
		else if (isDamaged == true && playerHealth <= 0) 
		{
			gameObject.renderer.enabled = false;
			
			// Reset starting position to the spawn point
			gameObject.transform.position = spawnPoint.position;
			gameObject.renderer.enabled = true;
			playerHealth = 5.0f;
			
		}
	}
	
	void OnGUI() {
		GUI.Label (new Rect(10, 10, 100, 20), "Health: " + playerHealth, style);
	}
}
