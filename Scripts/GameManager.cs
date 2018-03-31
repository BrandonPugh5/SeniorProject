using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public Transform spawnPoint;
	public Transform player;
	// Use this for initialization

	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Reset")) {
			SceneLoader.sceneToLoad = SceneManager.GetActiveScene ().name;
			SceneLoader.loadScene = true;
		}
	}
}
