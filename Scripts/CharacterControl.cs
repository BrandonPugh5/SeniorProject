using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    private Move moveScript;
    private bool isJumping;

    void Awake()
    {
        moveScript = GetComponent<Move>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isJumping)
        {
            isJumping = Input.GetButtonDown("Jump");
        }
	}

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        moveScript.MoveCharacter(horizontal, isJumping);
        isJumping = false;
    }

}
