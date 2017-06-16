using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ZipVertical : MonoBehaviour {

	public GameObject brokenObeliskPrefab;


	public float zipSpeed;
	public float maxRange;
	public float zipStretchSpeed;
	public float obeliskHitStretch;
	public bool idle;
	public float obeliskSpawn1;
	public float obeliskSpawn2;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.localScale += new Vector3 (zipStretchSpeed, 0, 0);
		if (transform.position.y < maxRange) {
			transform.Translate (Vector3.up * zipSpeed * Time.deltaTime);
		} else {
			if(idle == false)
			InstantiateObelisk ();
		}
	}

	public void increaseSize(int increaseType, float rangeIncrease)
	{
		switch (increaseType) {
		case 1:
			transform.localScale += new Vector3 (obeliskHitStretch, 0, 0);
			break;
		case 2:
			transform.localScale += new Vector3 (rangeIncrease, 0, 0);
			break;
		}
	
	}

	void InstantiateObelisk()
	{
		idle = true;
		GameObject.Instantiate (brokenObeliskPrefab, new Vector3(transform.position.x,0.1f,0), Quaternion.identity);
	}
}
