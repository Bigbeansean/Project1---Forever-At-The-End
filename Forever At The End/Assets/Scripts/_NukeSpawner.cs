﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _NukeSpawner : MonoBehaviour {

	public GameObject nukePrefab;
	public float fireTime;
	public float fireRate;
	public float nukeSpeed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		fireTime -= Time.deltaTime;
		if (fireTime <= 0) {
			FireNuke();
		}
	}

	void FireNuke(){
		Rigidbody nuke;
		nuke = Instantiate (nukePrefab, transform.position, transform.rotation).GetComponent<Rigidbody> ();;
		nuke.velocity = transform.TransformDirection (Vector3.forward * nukeSpeed);
		fireTime = fireRate;
	}
}