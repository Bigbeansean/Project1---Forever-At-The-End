using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MissileSpawner : MonoBehaviour
{
	private GameObject clone;
	public GameObject cursorPrefab;
	public float missileSpeed;
	public string turret;
	public string keyboardInput;

	// Use this for initialization
	void Start ()
	{ 
		if (gameObject.transform.position.x == 0) {
			turret = "1";
			keyboardInput = "f";
		}
		if (gameObject.transform.position.x == -2) {
			turret = "2";
			keyboardInput = "d";
		}
		if (gameObject.transform.position.x == 2) {
			turret = "3";
			keyboardInput = "g";
		}
		if (gameObject.transform.position.x == -4) {
			turret = "4";
			keyboardInput = "s";
		}
		if (gameObject.transform.position.x == 4) {
			turret = "5";
			keyboardInput = "h";
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (keyboardInput)) {
			clone = Instantiate (cursorPrefab, transform.position, Quaternion.identity);
			CursorHold cursorHold = clone.GetComponent<CursorHold> ();
			cursorHold.turretSelect = keyboardInput;
		}
	}
}