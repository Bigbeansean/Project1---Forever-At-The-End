using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class _Nuke : MonoBehaviour
{

	public GameObject miniExplosionPrefab;
	public GameObject explosionPrefab;

	public Renderer rend;
	public Material middleMat;
	public Material leftRightMat;
	public Material farLeftRighMat;

	public int scoreIncrease;



	// Use this for initialization
	void Start ()
	{

		rend = GetComponent<Renderer> ();
		rend.enabled = true;

		if (transform.position.x == 0) {
			rend.material = middleMat;
		}
		if (transform.position.x == -2 || transform.position.x == 2) {
			rend.material = leftRightMat;
		}
		if (transform.position.x == -4 || transform.position.x == 4) {
			rend.material = farLeftRighMat;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
		if (gameManagerObject.endGame == true) {
			GameObject.Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter (Collider other)
	{
		_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
		_ZipVertical zipObject = GameObject.FindGameObjectWithTag ("ZipTag").GetComponent<_ZipVertical> ();
		if (other.gameObject.tag == "BrokenObelisk") {
			GameObject.Instantiate (miniExplosionPrefab, transform.position, Quaternion.identity);
			zipObject.increaseSize (1, 0);
			gameManagerObject.DecreaseMultiplier (5);
			Destroy (gameObject);		
		}
		if (other.gameObject.tag == "Explosion") {
			GameObject.Instantiate (miniExplosionPrefab, transform.position, Quaternion.identity);
			gameManagerObject.IncreaseMultiplier (1);
			gameManagerObject.IncreaseScore (scoreIncrease);
			Destroy (gameObject);		
		}
	}
}