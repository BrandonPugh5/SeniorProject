using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public Transform target; //Assign to the object you want to rotate
    Vector3 object_pos;
    public int rotationOffset;
    //private float x;
    //private Vector3 ls;
    private bool gunIsFacingRight, playerIsFacingRight;

    private GameObject rayGun, playerRig;

    private void Start()
    {
        //x = transform.localScale.x;
        //ls = transform.localScale;
        rayGun = GameObject.Find("RayGun");
        playerRig = GameObject.Find("PlayerRig");
    }

    void Update()
    {
        gunIsFacingRight = playerIsFacingRight;

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);

        if(rotationZ > -90f && rotationZ < 90 && !gunIsFacingRight)
        {
            if(rayGun.name != null
                && rayGun.transform.IsChildOf(transform))
            {
                Flip();
            }
        }
        else if((rotationZ < -90f || rotationZ > 90) && gunIsFacingRight)
        {
            if (rayGun.name != null 
                && rayGun.transform.IsChildOf(transform))
            {
                Flip();
            }
        }

        if(rotationZ < -90f || rotationZ > 90)
        {
            gunIsFacingRight = false;
        }
        else
        {
            gunIsFacingRight = true;
        }

        //Vector3 mouse_pos = Input.mousePosition;
        //mouse_pos.z = 5.23f; //The distance between the camera and object
        //object_pos = Camera.main.WorldToScreenPoint(target.position);
        //mouse_pos.x = mouse_pos.x - object_pos.x;
        //mouse_pos.y = mouse_pos.y - object_pos.y;
        //angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //target.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Flip()
    {
        SpriteRenderer gunRenderer = rayGun.GetComponent<SpriteRenderer>();
        gunRenderer.flipY = !gunRenderer.flipY;


        //GameObject playerBody = GameObject.Find("Body");
        //SpriteRenderer bodyRenderer = playerBody.GetComponent<SpriteRenderer>();
        //bodyRenderer.flipX = !bodyRenderer.flipX;



        Transform body = playerRig.transform.Find("Body");

        Vector3 theScale = body.localScale;
        theScale.x *= -1;
        body.localScale = theScale;

        playerIsFacingRight = body.localScale.x > 0;

        if (playerIsFacingRight)
        {
            gunRenderer.flipY = true;
            gunRenderer.flipX = true;
            
        }
        else
        {
            gunRenderer.flipY = false;
            gunRenderer.flipX = true;
        }
        
        //foreach (Transform bodyPart in body)
        //{
           
        //    SpriteRenderer bodyPartsRenderer = bodyPart.gameObject.GetComponent<SpriteRenderer>();
        //    bodyPartsRenderer.flipX = !bodyPartsRenderer.flipX;
            
        //}

    }
}
