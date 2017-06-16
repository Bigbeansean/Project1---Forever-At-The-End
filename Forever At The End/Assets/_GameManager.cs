using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GameManager : MonoBehaviour {

	public float time;
	public string timeDisplay;
	public Text timeText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		timeDisplay = time.ToString ("F0");
		timeText.text = ("Time: " + timeDisplay);
	}
}
