using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BrokenObelisk : MonoBehaviour
{

	public GameObject explosionPrefab;

	public GameObject nukeSpawner;
	public GameObject zipPrefab;
	public GameObject maxRange;

	public float nukeSpawerLocation;

	// Use this for initialization
	void Start ()
	{
		GameObject.Instantiate (nukeSpawner, new Vector3 (transform.position.x, nukeSpawerLocation, transform.position.z), Quaternion.Euler (90, 0, 0));
		GameObject.Instantiate (zipPrefab, new Vector3 (transform.position.x,transform.position.y - 10,transform.position.z + 0.62f), Quaternion.identity);
		GameObject.Instantiate (maxRange, new Vector3 (0,8.28f,0.5f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
	{
		_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
		if (gameManagerObject.endGame == true) {
			GameObject.Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	void Destroy()
	{

	}
}
