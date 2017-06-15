using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHold : MonoBehaviour
{
	
	public float cursorSpeed;
	public float maxRange;

	public GameObject explosionPrefab;

	public string turretSelect;


	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.up * cursorSpeed * Time.deltaTime);

		if (transform.position.y >= maxRange) {
			DestroySelf ();
		}

		if (Input.GetKeyUp (turretSelect)) {
			DestroySelf ();
		}
	}

	public void DestroySelf ()
	{
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
