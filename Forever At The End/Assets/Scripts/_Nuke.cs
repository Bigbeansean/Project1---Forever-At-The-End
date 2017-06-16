using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Nuke : MonoBehaviour
{

	public GameObject miniExplosionPrefab;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void OnTriggerEnter (Collider other)
	{
		_ZipVertical zipObject = GameObject.FindGameObjectWithTag ("ZipTag").GetComponent<_ZipVertical> ();
		if (other.gameObject.tag == "BrokenObelisk") {
			zipObject.increaseSize (1, 0);
			Destroy (gameObject);		
		}
		if (other.gameObject.tag == "Explosion") {
			GameObject.Instantiate (miniExplosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);		
		}
	}
}