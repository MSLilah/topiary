using UnityEngine;
using System.Collections;

public class HedgeController : MonoBehaviour {
	public enum HedgeState {DEAD, TRIMMED, OVERGROWN};
	public HedgeState state = HedgeState.TRIMMED;

	void Update() {
		SpriteRenderer spriteRenderer = renderer as SpriteRenderer;
		switch (state) {
			case HedgeState.OVERGROWN:
				spriteRenderer.color = Color.red;
				break;
			case HedgeState.TRIMMED:
				spriteRenderer.color = Color.green;
				break;
			case HedgeState.DEAD:
				spriteRenderer.color = Color.gray;
				collider2D.enabled = false;
				break;
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
