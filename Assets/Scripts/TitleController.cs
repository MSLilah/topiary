using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Fire1") != 0) {
			Application.LoadLevel (1);
		}
	}
}