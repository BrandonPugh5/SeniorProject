using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour {
	public GateManager gm;
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Object") 
		{
			gm.OpenRedGate();
		}
	}
}
