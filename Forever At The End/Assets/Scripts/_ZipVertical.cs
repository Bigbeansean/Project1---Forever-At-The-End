using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ZipVertical : MonoBehaviour {

	public float zipSpeed;
	public float maxRange;
	public float zipStretchSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale += new Vector3 (zipStretchSpeed, 0, 0);
		if (transform.position.y < maxRange) {
			transform.Translate (Vector3.up * zipSpeed * Time.deltaTime);
		} 
	}

	public void increaseSize()
	{
		transform.localScale += new Vector3 (1, 0, 0);
	}
}
