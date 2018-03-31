using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable {

    Animator buttonPushAnimation;
    
    private void Awake()
    {
        buttonPushAnimation = GetComponent<Animator>();
    }
	
    public override void Interact()
    {
        buttonPushAnimation.SetBool("hasInteracted", true);
    }

}
