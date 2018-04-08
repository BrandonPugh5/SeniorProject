using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    double lifetime = 1.0;
    public bool shrinkable;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Shootable" && shrinkable)
        {
            col.transform.localScale *= .80f;
        }
        else if (col.gameObject.tag == "Shootable" && !shrinkable)
        {
            col.transform.localScale *= 1.05f;
        }
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        lifetime -= 0.7 * Time.deltaTime;
        if (lifetime <= 0.0)
            Destroy(gameObject);

    }
}
