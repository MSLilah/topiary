using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	public Camera MainCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(MainCamera.transform.position.x,
										 MainCamera.transform.position.y,
										 transform.position.z);
	}
}
