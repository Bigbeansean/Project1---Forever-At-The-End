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
	public float parachuteSpeed;
	public float minSpawnTime;
	public float maxSpawnTime;
	public float spawnTimeDecrease;

	public float spawn1MinTime;
	public float spawn2MinTime;
	public float spawn1MaxTime;
	public float spawn2MaxTime;

	public float parachuteDelay;

	public int spawnSection;

	public int numberObelisks;


	// Use this for initialization
	void Start ()
	{
		
		parachuteTime = Random.Range (minSpawnTime + 10, maxSpawnTime + 15);
		fireTime = Random.Range (minSpawnTime -1, maxSpawnTime - 1);
	}

	// Update is called once per frame
	void Update ()
	{
		
		_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
		if (gameManagerObject.endGame == true) {
			Destroy (gameObject);
		}
		numberObelisks = gameManagerObject.numberObelisks;
		fireTime -= Time.deltaTime;
		parachuteTime -= Time.deltaTime;

		if (minSpawnTime > 1) {
			minSpawnTime -= spawnTimeDecrease * Time.deltaTime;
			maxSpawnTime -= spawnTimeDecrease * Time.deltaTime;
		}
		if (fireTime <= 0) {
			FirePrefab (1);
		}
		if (parachuteTime <= 0) {
			FirePrefab (2);
		}
		if (numberObelisks == 3 && spawnSection == 1) {
			minSpawnTime = spawn1MinTime;
			maxSpawnTime = spawn1MaxTime;
			spawnSection = 2;
		}
		if (numberObelisks == 5 && spawnSection == 2) {
			minSpawnTime = spawn2MinTime;
			maxSpawnTime = spawn2MaxTime;
			spawnSection = 0;
		}
	}

	void FirePrefab (int selectPrefab)
	{
		switch (selectPrefab) {
		case 1:
			Rigidbody nuke;
			nuke = Instantiate (nukePrefab, transform.position, transform.rotation).GetComponent<Rigidbody> ();;
			nuke.velocity = transform.TransformDirection (Vector3.forward * nukeSpeed);
			fireTime = Random.Range (minSpawnTime, maxSpawnTime);
			parachuteTime += parachuteDelay;
			break;

		case 2:
			Rigidbody parachute;
			parachute = Instantiate (parachutePrefab, transform.position, transform.rotation).GetComponent<Rigidbody> ();;
			parachute.velocity = transform.TransformDirection (Vector3.forward * parachuteSpeed);
			parachuteTime = Random.Range (minSpawnTime + 10, maxSpawnTime + 10);
			fireTime = Random.Range (minSpawnTime, maxSpawnTime);
			break;
		}
	}
}
