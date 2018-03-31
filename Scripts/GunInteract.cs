using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInteract : Interactable {

    public bool hadFirstInteraction;

    public string[] dialogue;
    public string npcName;

    public static bool isHeldByPlayer;

    public float gunRotationAmount;

    private void Update()
    {
        if (transform.parent == GameObject.Find("Player").transform.Find("PlayerRig").Find("RightArm"))
        {
            isHeldByPlayer = true;
        }
    }
    public override void Interact()
    {
        foreach (Collider2D col in overlapCircle)
        {
            if (col.gameObject.tag == "Player" && !hadFirstInteraction)
            {

                Transform player = col.gameObject.transform;
                Transform playerRightArm = player.Find("PlayerRig").Find("RightArm");
                Vector3 gunPosition = playerRightArm.Find("Gun Position").position;
                hasInteracted = true;
                hadFirstInteraction = true;
                transform.position = gunPosition;
                transform.rotation = Quaternion.Euler(0f, 0f, gunRotationAmount);
                transform.SetParent(playerRightArm);
                isHeldByPlayer = transform.parent == playerRightArm;

                if (playerRightArm.localEulerAngles.z < 180 && playerRightArm.localEulerAngles.z > 0)
                {
                    transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + 180));
                }
                else
                {
                    transform.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }


            }
        }
        DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);

    }
}
