using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable {

    public GameObject gate;
    Animator leverAnimation;


    private void Awake()
    {
        leverAnimation = GetComponent<Animator>();
    }

    public override void Interact()
    {
        leverAnimation.SetBool("hasInteracted", true);
        Destroy(gate);
    }
}
