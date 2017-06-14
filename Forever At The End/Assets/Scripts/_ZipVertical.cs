using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ZipVertical : MonoBehaviour {

	public float zipSpeed;
	public float maxRange;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < maxRange) {
			transform.Translate (Vector3.up * zipSpeed * Time.deltaTime);
		} 
	}
}
