using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerFix : MonoBehaviour {

    public Renderer r;
    public int sortingOrder;
    // Use this for initialization
    void Start () {
        r = GetComponent<Renderer>();
        r.sortingOrder = this.transform.parent.GetComponent<Renderer>().sortingOrder;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
