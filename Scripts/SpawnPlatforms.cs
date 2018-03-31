using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour {
	public float timer = 3;
	public GameObject downPlat;
	public GameObject upPlat;
	public Vector2 downSpawn;
	public Vector2 upSpawn;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= 1 * Time.deltaTime;
		if (timer <= 0f) 
		{
            GameObject upPlatClone = Instantiate (upPlat, upSpawn, transform.rotation);
            GameObject downPlatClone = Instantiate (downPlat, downSpawn, transform.rotation);
			timer = 3;
		}
	}
}
