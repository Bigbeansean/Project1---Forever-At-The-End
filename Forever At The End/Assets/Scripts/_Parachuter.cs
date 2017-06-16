using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Parachuter : MonoBehaviour {
	
	public int parachuteScore;
	public GameObject miniExplosionPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter (Collider other)
	{
		_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
		if (other.gameObject.tag == "BrokenObelisk") {
			gameManagerObject.IncreaseScore (parachuteScore);
			Destroy (gameObject);		
		}
		if (other.gameObject.tag == "Explosion") {
			GameObject.Instantiate (miniExplosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);		
		}
	}

}
