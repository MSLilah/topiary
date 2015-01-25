using UnityEngine;
using System.Collections;

public class HedgeController : MonoBehaviour {
	public enum HedgeState {DEAD, TRIMMED, OVERGROWN};
	public HedgeState state = HedgeState.TRIMMED;
	public Sprite trimmedSprite;
	public Sprite overgrownSprite;
	public Sprite deadSprite;
	
	private Animator animator;
	
	void Start() {
		animator = GetComponent<Animator>();
	}

	void Update() {
		
		animator.SetInteger("HedgeState", (int)state);
		
		if (state == HedgeState.DEAD) {
			collider2D.enabled = false;
		}
		
	}
	
	public void DecreaseState() {
		if (state != HedgeState.DEAD) {
			state--;
		}
	}
	
	public void SetState(HedgeState newState) {
		state = newState;
	}
}
