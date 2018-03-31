using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public bool hasInteracted;

    public float radius;
    public LayerMask playerLayer;
    [SerializeField]
    public Collider2D[] overlapCircle;
    public InteractionType interactionType;

    private void Start()
    {
       
    }

    public enum InteractionType
    {
        pressE,
        withinRange,
        stepOn
    };

    //have interact types enum so you can choose different ways to interact and apply this script to other objects.

    private void Update()
    {
        overlapCircle = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius, playerLayer);
        foreach (Collider2D col in overlapCircle)
        {
            if (!hasInteracted && interactionType == InteractionType.withinRange)
            {
                Interact();
                hasInteracted = true;
            }
            if(interactionType == InteractionType.pressE 
                && Input.GetButtonDown("Interact"))
            {
                Interact();
            }
            if(interactionType == InteractionType.stepOn)
            {
                Interact();
            }
        }
    }

    public virtual void Interact()
    {

    }

}
