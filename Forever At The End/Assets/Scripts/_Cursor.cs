using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Cursor : MonoBehaviour {

	public float minRange;
	public float maxRange;
	public float cursorSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < maxRange)
		{
			if (Input.GetKey ("a")) {
				transform.Translate (Vector3.up * cursorSpeed * Time.deltaTime);
			}
		}
		if (transform.position.y > minRange) {
			if (Input.GetKey ("z")) {
				transform.Translate (Vector3.down * cursorSpeed * Time.deltaTime);
			}
		}
	}
}
