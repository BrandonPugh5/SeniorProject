using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interactable {
    
    Animator pressurePlateAnimation;
    public GameObject whatCanCollide;
    public GameObject gate;

    private void Awake()
    {
        pressurePlateAnimation = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == whatCanCollide)
        {
            Interact();
        }
        if (collision.gameObject.tag.Equals("Trigger"))
        {
            Destroy(gate);
        }
    }

    public override void Interact()
    {
        pressurePlateAnimation.SetBool("hasInteracted", true);
        Destroy(gate);
    }

}
