using UnityEngine;
using System.Collections;

public class TerrainController : MonoBehaviour {

	private Animator animator;
	
	void Start () {
		animator = GetComponent<Animator>();
		WorldStateChange (true);
	}
	
	public void WorldStateChange(bool lightWorld) {
		animator.SetBool ("LightWorld", lightWorld);
	}
}
