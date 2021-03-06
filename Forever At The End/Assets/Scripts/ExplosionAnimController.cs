﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimController : MonoBehaviour
{

	public float timeToExplosion;
	public float counter;
	public float min = 1, max = 2;
	public AnimationCurve remapCurve = AnimationCurve.Linear (0, 0, 1, 1);

	public bool hit;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		counter += Time.deltaTime;
		counter %= (timeToExplosion * 2);

		float p = Mathf.PingPong (counter / timeToExplosion, 1);
		p = remapCurve.Evaluate (p);

		transform.localScale = Vector3.one * Mathf.LerpUnclamped (min, max, p);

		if (counter >= timeToExplosion) {
			if (hit == false) 
			{
				_GameManager gameManagerObject = GameObject.FindGameObjectWithTag ("GameController").GetComponent<_GameManager> ();
				gameManagerObject.DecreaseMultiplier (2);
			}
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Nuke") {
			hit = true;
		}
	}
}
