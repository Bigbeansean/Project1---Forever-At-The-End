using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BrokenObelisk : MonoBehaviour
{

	public GameObject nukeSpawner;

	public float nukeSpawerLocation;

	// Use this for initialization
	void Start ()
	{
		GameObject.Instantiate (nukeSpawner, new Vector3 (transform.position.x, nukeSpawerLocation, transform.position.z), Quaternion.Euler (90, 0, 0));
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
