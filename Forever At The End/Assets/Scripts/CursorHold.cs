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

	public int numberObelisks;

	public string turretSelect;

	// Use this for initialization
	void Start ()
	{
		_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
		numberObelisks = gameManagerObject.numberObelisks;
	
		explosionRange = maxRange + explosionRangeModifier;
	}

	// Update is called once per frame
	void Update ()
	{
		_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
		if (gameManagerObject.endGame == true) {
			GameObject.Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
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
		_ZipVertical zipObject = GameObject.FindGameObjectWithTag ("ZipTag").GetComponent<_ZipVertical> ();
		zipObject.increaseSize (2, (explosionRange - transform.position.y) * explosionMultiplier / numberObelisks);
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
