﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _NukeSpawner : MonoBehaviour
{

	public GameObject nukePrefab;
	public float fireTime;
	public float nukeSpeed;
	public float nukeSpeedIncrease;
	public float minSpawnTime;
	public float maxSpawnTime;
	public float spawnTimeDecrease;




	// Use this for initialization
	void Start ()
	{
		fireTime = Random.Range (minSpawnTime, maxSpawnTime);
	}

	// Update is called once per frame
	void Update ()
	{
		fireTime -= Time.deltaTime;
		if (minSpawnTime > 1) {
			minSpawnTime -= spawnTimeDecrease * Time.deltaTime;
			maxSpawnTime -= spawnTimeDecrease * Time.deltaTime;
		}
		if( minSpawnTime <= 1){
			nukeSpeed += nukeSpeedIncrease * Time.deltaTime;
		}
		if (fireTime <= 0) {
			FireNuke ();
		}
	}

	void FireNuke ()
	{
		Rigidbody nuke;
		nuke = Instantiate (nukePrefab, transform.position, transform.rotation).GetComponent<Rigidbody> ();;
		nuke.velocity = transform.TransformDirection (Vector3.forward * nukeSpeed);
		fireTime = Random.Range (minSpawnTime, maxSpawnTime);
	}
}
