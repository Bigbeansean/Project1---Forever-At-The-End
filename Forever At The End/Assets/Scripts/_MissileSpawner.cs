using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MissileSpawner : MonoBehaviour {

	public GameObject missilePrefab;
	public float fireTime;
	public float fireRate;
	public int ammo;
	public int maxAmmo;
	public int warningAmmo;
	public float missileSpeed;

	// Use this for initialization
	void Start () {
		ammo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update () {
		fireTime -= Time.deltaTime;
		if (fireTime <= 0 && Input.GetKeyDown("q") && ammo > 0) {
			FireMissile();
		}
	}

	void FireMissile(){
		Rigidbody missile;
		missile = Instantiate (missilePrefab, transform.position, transform.rotation).GetComponent<Rigidbody> ();;
		missile.velocity = transform.TransformDirection (Vector3.forward * missileSpeed);
		fireTime = fireRate;
		ammo -= 1;
	}
}
