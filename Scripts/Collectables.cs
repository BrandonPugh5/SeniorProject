using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Destroy (this.gameObject);
		}
	}
}

