using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

	GameObject gameManager;

	void Awake ()
	{
		gameManager = GameObject.Find ("GameManager");
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			print ("collided");
			gameManager.GetComponent<PuzzleCompletionScript> ().isPuzzleCompleted = true;
		}
	}
}
	
