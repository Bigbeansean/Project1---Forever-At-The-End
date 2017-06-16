using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GameManager : MonoBehaviour {

	public float time;
	public string timeDisplay;
	public Text timeText;

	public int score;

	public GameObject obeliskPrefab;
	public GameObject[] obelisks;

	public int numberObelisks;

	public int multiplier;
	public int multiplierDecreaser;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		timeDisplay = time.ToString ("F0");
		timeText.text = ("Time: " + timeDisplay);
		obelisks = GameObject.FindGameObjectsWithTag ("BrokenObelisk");
		numberObelisks = obelisks.Length;
	}

	public void IncreaseScore(int addScore)
	{
		score += addScore * multiplier;
	}

	public void DecreaseMultiplier()
	{
		multiplier -= multiplierDecreaser;

		if (multiplier < 1) {
			multiplier = 1;
		}
	}
}
