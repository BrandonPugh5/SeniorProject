using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {
	

	public void OpenBlueGate()
	{
		GameObject[] blues = GameObject.FindGameObjectsWithTag ("BlueGate");
		foreach (GameObject b in blues)
			Destroy (b.gameObject);
	}

	public void OpenOrangeGate()
	{
        GameObject[] oranges = GameObject.FindGameObjectsWithTag ("OrangeGate");
		foreach (GameObject o in oranges)
			Destroy (o.gameObject);
	}

	public void OpenYellowGate()
	{
        GameObject[] yellows = GameObject.FindGameObjectsWithTag ("YellowGate");
		foreach (GameObject y in yellows)
			Destroy (y.gameObject);
	}

	public void OpenGreenGate()
	{
        GameObject[] greens = GameObject.FindGameObjectsWithTag ("GreenGate");
		foreach (GameObject g in greens)
			Destroy (g.gameObject);
	}

	public void OpenRedGate()
	{
        GameObject[] reds = GameObject.FindGameObjectsWithTag ("RedGate");
		foreach (GameObject r in reds)
			Destroy (r.gameObject);
	}
}
