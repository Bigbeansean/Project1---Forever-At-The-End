using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Missile : MonoBehaviour {

	public Vector3 target;
	public GameObject explosion;
	public int turretSelect;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Cursor").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= target.y) {
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}