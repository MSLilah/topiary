// --------------------------------------------------
// Author: Christian Scandariato
// Date: 01/18/2015
// Credit: Code Foundation: Experiment 2 Files: https://assethub.fso.fullsail.edu/assethub/Exp_2_StateMachines_c9c28992-772b-4340-adb1-b194888a6f5d.pdf
// Credit: Code Foundation: Experiment 3 Files: https://course.fso.fullsail.edu/class_sections/22805/assignments/453444

// Purpose: A class used to hold the soft platform's data variables.
// --------------------------------------------------

using UnityEngine;
using System.Collections;

public class SoftPlatform : MonoBehaviour 
{
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
