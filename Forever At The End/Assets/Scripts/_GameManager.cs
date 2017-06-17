using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _GameManager : MonoBehaviour {

	public float time;
	public string timeDisplay;

	public bool endGame;

	public int numberObelisks;
	public int score;
	public int multiplier;

	public GameObject zip;
	public GameObject obeliskPrefab;
	public GameObject[] obelisks;

	public Text timeText;
	public Text multiplierText;
	public Text scoreText;
	public Text endScore;

	public float deathTimer;

	// Use this for initialization
	void Start () {
		endScore.text = " ";
	}
	
	// Update is called once per frame
	void Update () {
		if (zip != null) {
			time += Time.deltaTime;
		}
		if (endGame == true) {
			endScore.text = ("Score: " + score);
			scoreText.text = " ";
			deathTimer -= Time.deltaTime;
			if (deathTimer <= 0) {
				SceneManager.LoadScene ("MainMenu");
			}
		}
		if (endGame == false) {
			timeDisplay = time.ToString ("F0");
			timeText.text = ("Time: " + timeDisplay);
			multiplierText.text = (multiplier + " x");
			scoreText.text = ("Score: " + score);

		}

		obelisks = GameObject.FindGameObjectsWithTag ("BrokenObelisk");
		zip = GameObject.FindGameObjectWithTag ("ZipTag");
		numberObelisks = obelisks.Length;
	}

	public void IncreaseScore(int addScore)
	{
		score += addScore * multiplier;
	}

	public void DecreaseMultiplier(int multiplierDecreaser)
	{
		multiplier -= multiplierDecreaser;

		if (multiplier < 1) {
			multiplier = 1;
		}
	}

	public void IncreaseMultiplier(int multiplierIncreaser)
	{
		multiplier += multiplierIncreaser;
	}

	public void EndGame()
	{
		endGame = true;
	}
}
