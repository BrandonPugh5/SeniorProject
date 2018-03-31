using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompletionScript : MonoBehaviour
{

	public bool isPuzzleCompleted;

	public GameObject[] doors;

	void Update ()
	{
		print ("update");
		if (isPuzzleCompleted) {
			print ("working");
			foreach (GameObject door in doors) {
				door.GetComponent<SpriteRenderer> ().color = Color.blue;
			}
		}
	}
}
