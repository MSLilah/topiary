using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public GameObject bullet;
	public Transform bulletSpawner;
	private bool canFire = true;
	private float fireTimer = 0.0f;
	public float fireInterval = 0.2f;
	private AudioSource gunAudio;
	
	public Animator muzzleAnimator;
	
	void FixedUpdate () {
		Fire ();
		AudioSource[] audios = GetComponents<AudioSource>();
		gunAudio = audios [2];
		gunAudio.volume = 0.3f;
	}
	
	void Update() {
		if (!canFire) {
			fireTimer += Time.deltaTime;
			if (fireTimer >= fireInterval) {
				canFire = true;
			}
		}
	}
	
	void Fire() {
		if (Input.GetAxisRaw ("Fire1") != 0 && canFire) {
			muzzleAnimator.SetTrigger("Shoot");
			CreateBullet();
			gunAudio.Play ();
			canFire = false;
		}
	}
	
	public void CreateBullet() {
		GameObject newBullet = Instantiate(bullet, bulletSpawner.position, Quaternion.identity) as GameObject;
		newBullet.GetComponent<BulletController>().facingRight = GetComponent<PlayerController>().facingRight;
		fireTimer = 0.0f;
		canFire = false;
	}
}
