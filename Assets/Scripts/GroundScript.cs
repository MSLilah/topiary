using UnityEngine;
using System.Collections;

public class GroundScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
	{
		//If the player enters from the bottom
		if (col.tag == "Player") 
		{
			// Ignore collisions allowing it to pass through
			Physics2D.IgnoreCollision (col, transform.parent.collider2D, true);
		}
	}
	
	void OnTriggerExit2D (Collider2D col)
	{
		// If the player has fully passed through
		if (col.tag == "Player")
		{
			// Turn collision back on
			Physics2D.IgnoreCollision (col, transform.parent.collider2D, false);
		}
	}
}
