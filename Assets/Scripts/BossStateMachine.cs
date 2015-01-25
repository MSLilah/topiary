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

	private float bossHealth = 75;

	private BossStates curState;

	[SerializeField] private GameObject whipCollider;
	[SerializeField] private Transform whipTrans;

	[SerializeField] private GameObject bossGnome;
	[SerializeField] private Transform gnomeSpawn1;
	[SerializeField] private Transform gnomeSpawn2;
	[SerializeField] private Transform gnomeSpawn3;
	[SerializeField] private Transform gnomeSpawn4;
	
	private Vector2 moveForce;
	private Vector2 upForce;

	Dictionary <BossStates, Action> fsm = new Dictionary<BossStates, Action> ();

	// Use this for initialization
	void Start () 
	{
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
		stateTimer += Time.deltaTime;

		if (stateTimer >= 3.0f) 
		{
			Instantiate (bossGnome, gnomeSpawn1.position, Quaternion.identity);
			Instantiate (bossGnome, gnomeSpawn2.position, Quaternion.identity);
			Instantiate (bossGnome, gnomeSpawn3.position, Quaternion.identity);
			Instantiate (bossGnome, gnomeSpawn4.position, Quaternion.identity);

			SetState (BossStates.IDLE);
		}
	}

	public void IdleState ()
	{

		stateTimer += Time.deltaTime;

		if (stateTimer >= 5.0f) 
		{
			SetState (BossStates.WHIP);
			stateTimer = 0.0f;
		}
	}


	public void MoveState ()
	{

	}

	public void WhipState ()
	{
		Instantiate (whipCollider, whipTrans.position, Quaternion.identity);
		SetState (BossStates.GNOME);
	}

	public void MoveBoss ()
	{
	}

	public void spawnGnomes ()
	{

	}
}
