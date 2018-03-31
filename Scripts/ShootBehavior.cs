using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour {

    Rigidbody2D rb;

    private void Awake()
    {
        rb = transform.Find("Chicken Nugget 1").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Bullet"
            && GunBehavior.currentGunMode == GunBehavior.GunMode.grow)
        {
            rb.simulated = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
