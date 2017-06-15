using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Nuke : MonoBehaviour
{
	GameObject zip;
	// Use this for initialization
	void Start ()
	{
		zip = GameObject.FindGameObjectWithTag ("Zip");
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Explosion")
			Destroy (gameObject);
		if (other.gameObject.tag == "BrokenObelisk")
			Destroy (gameObject);
	}
}