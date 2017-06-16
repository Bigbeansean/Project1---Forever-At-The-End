using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHold : MonoBehaviour
{
	
	public float cursorSpeed;
	public float maxRange;
	public float explosionRange;
	public float explosionRangeModifier;
	public float explosionMultiplier;

	public GameObject explosionPrefab;

	public GameObject obeliskPrefab;
	public GameObject[] obelisks;

	public string turretSelect;

	public int numberObelisks;

	// Use this for initialization
	void Start ()
	{
		explosionRange = maxRange + explosionRangeModifier;
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.up * cursorSpeed * Time.deltaTime);
		obelisks = GameObject.FindGameObjectsWithTag ("BrokenObelisk");
		numberObelisks = obelisks.Length;
		if (transform.position.y >= maxRange) {
			DestroySelf ();
		}
		if (Input.GetKeyUp (turretSelect)) {
			DestroySelf ();
		}
	}

	public void DestroySelf ()
	{
		_ZipVertical zipObject = GameObject.FindGameObjectWithTag ("ZipTag").GetComponent<_ZipVertical> ();
		zipObject.increaseSize (2, (explosionRange - transform.position.y) * explosionMultiplier / numberObelisks);
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
