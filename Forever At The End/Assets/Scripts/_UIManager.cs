using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _UIManager : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void Launch()
	{
		SceneManager.LoadScene ("MainGame");
	}

	public void LaunchHow()
	{
		SceneManager.LoadScene ("HowToPlay");
	}

	public void Return()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
