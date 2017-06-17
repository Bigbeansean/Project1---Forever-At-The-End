using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Parachuter : MonoBehaviour {
	
	public int parachuteScore;
	public int parachuteMultiplierMinus;
	public int parachuteMultiplierPlus;
	public GameObject miniExplosionPrefab;
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
		if (gameManagerObject.endGame == true) {
			GameObject.Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter (Collider other)
	{
		_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
		if (other.gameObject.tag == "BrokenObelisk") {
			gameManagerObject.IncreaseScore (parachuteScore);
			gameManagerObject.IncreaseMultiplier (parachuteMultiplierPlus);
			Destroy (gameObject);		
		}
		if (other.gameObject.tag == "Explosion") {
			GameObject.Instantiate (miniExplosionPrefab, transform.position, Quaternion.identity);
			gameManagerObject.DecreaseMultiplier (parachuteMultiplierMinus);
			Destroy (gameObject);		
		}
	}

}
