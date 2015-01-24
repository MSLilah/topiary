using UnityEngine;
using System.Collections;

public class PlayerScriptCS : MonoBehaviour {


	//Player health and damage
	private float playerHealth = 5.0f;
	private float playerInvulTime;
	private bool isDamaged;
	private float knockbackDir;
	private float enemyX;
	private float playerX;


	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Enemy" && !isDamaged) 
		{
			playerHealth--;
			
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
			Destroy (gameObject);
		}
		
	}
}
