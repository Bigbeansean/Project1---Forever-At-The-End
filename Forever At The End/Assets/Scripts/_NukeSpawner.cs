using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _NukeSpawner : MonoBehaviour
{

	public GameObject nukePrefab;
	public GameObject parachutePrefab;

	public float fireTime;
	public float parachuteTime;
	public float nukeSpeed;
	public float nukeSpeedIncrease;
	public float minSpawnTime;
	public float maxSpawnTime;
	public float spawnTimeDecrease;

	public int numberObelisks;


	// Use this for initialization
	void Start ()
	{
		
		parachuteTime = Random.Range (minSpawnTime + 10, maxSpawnTime + 15);
		fireTime = Random.Range (minSpawnTime, maxSpawnTime);
	}

	// Update is called once per frame
	void Update ()
	{
		_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
		numberObelisks = gameManagerObject.numberObelisks;
		fireTime -= Time.deltaTime;
		parachuteTime -= Time.deltaTime;
		if (minSpawnTime > 1) {
			minSpawnTime -= spawnTimeDecrease * Time.deltaTime;
			maxSpawnTime -= spawnTimeDecrease * Time.deltaTime;
		}
		if (minSpawnTime <= 1) {
			nukeSpeed += nukeSpeedIncrease * Time.deltaTime;
		}
		if (fireTime <= 0) {
			FireNuke ();
		}
		if (parachuteTime <= 0) {
			FireParachute ();
		}
	}

	void FireNuke ()
	{
		Rigidbody nuke;
		nuke = Instantiate (nukePrefab, transform.position, transform.rotation).GetComponent<Rigidbody> ();;
		nuke.velocity = transform.TransformDirection (Vector3.forward * nukeSpeed);
		fireTime = Random.Range (minSpawnTime, maxSpawnTime);
	}

	void FireParachute ()
	{
		Rigidbody parachute;
		parachute = Instantiate (parachutePrefab, transform.position, transform.rotation).GetComponent<Rigidbody> ();;
		parachute.velocity = transform.TransformDirection (Vector3.forward * nukeSpeed);
		parachuteTime = Random.Range (minSpawnTime + 10, maxSpawnTime + 10);
	}
}
