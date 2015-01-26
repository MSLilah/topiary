using UnityEngine;
using System.Collections;

using System;

using System.Collections.Generic;

public class BossStateMachine : MonoBehaviour {
	
	private enum BossStates
	{
		IDLE,
		WHIP,
		GNOME,
		MOVE,
		DEATH
	}
	 
	private float stateTimer = 0.0f;
	private float attackTimer;

	public float bossHealth = 30;

	private BossStates curState;

	[SerializeField] private GameObject bossGnome;
	[SerializeField] private Transform gnomeSpawn1;
	[SerializeField] private Transform gnomeSpawn2;
	[SerializeField] private Transform gnomeSpawn3;
	[SerializeField] private Transform gnomeSpawn4;
	
	private Vector2 moveForce;
	private Vector2 upForce;
	
	private Animator animator;
	
	private bool spawnedGnomes = false;

	Dictionary <BossStates, Action> fsm = new Dictionary<BossStates, Action> ();

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		fsm.Add (BossStates.DEATH, DeathState);
		fsm.Add (BossStates.GNOME, GnomeState);
		fsm.Add (BossStates.IDLE, IdleState);
		fsm.Add (BossStates.MOVE, MoveState);
		fsm.Add (BossStates.WHIP, WhipState);

		SetState (BossStates.IDLE);
		

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Bullet") 
		{
			bossHealth--;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bossHealth <= 0 && curState != BossStates.DEATH) {
			SetState(BossStates.DEATH);
			animator.SetTrigger ("Dead");
		}
		Debug.Log(curState);
		fsm[curState].Invoke ();
	}

	void SetState (BossStates nextState)
	{
		if (nextState != curState) 
		{
			curState = nextState;
		}
	}

	public void DeathState ()
	{

	}

	public void GnomeState ()
	{
		
//		stateTimer += Time.deltaTime;
//
//		if (stateTimer >= 3.0f) 
//		{
//			Instantiate (bossGnome, gnomeSpawn1.position, Quaternion.identity);
//			Instantiate (bossGnome, gnomeSpawn2.position, Quaternion.identity);
//			Instantiate (bossGnome, gnomeSpawn3.position, Quaternion.identity);
//			Instantiate (bossGnome, gnomeSpawn4.position, Quaternion.identity);
//
//			SetState (BossStates.IDLE);
//		}
	}

	public void IdleState ()
	{

		stateTimer += Time.deltaTime;

		if (stateTimer >= 5.0f) 
		{
			SetState (BossStates.WHIP);
			animator.SetTrigger("Slash");
			stateTimer = 0.0f;
		}
	}


	public void MoveState ()
	{

	}

	public void WhipState ()
	{
//		Instantiate (whipCollider, whipTrans.position, Quaternion.identity);
//		SetState (BossStates.GNOME);
//		animator.SetTrigger ("SpawnGnomes");
	}

	public void MoveBoss ()
	{
	}

	public void spawnGnomes ()
	{
		Instantiate (bossGnome, gnomeSpawn1.position, Quaternion.identity);
		Instantiate (bossGnome, gnomeSpawn2.position, Quaternion.identity);
		Instantiate (bossGnome, gnomeSpawn3.position, Quaternion.identity);
		Instantiate (bossGnome, gnomeSpawn4.position, Quaternion.identity);
		spawnedGnomes = true;
		SetState (BossStates.IDLE);
		animator.SetTrigger ("Idle");
	}
	
	public void finishWhip() {
		if (!spawnedGnomes) {
			SetState (BossStates.GNOME);
			animator.SetTrigger ("SpawnGnomes");
		}
		else {
			SetState (BossStates.IDLE);
			animator.SetTrigger("Idle");
		}
	}
	
	public void EndGame() {
		Application.LoadLevel (2);
	}
}
