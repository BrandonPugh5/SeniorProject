using UnityEngine;
using System;
using System.Collections.Generic;

public class GunBehavior : MonoBehaviour
{

	public GameObject bulletModel;
	private GameObject rightArm;
	private GameObject dialoguePanel;
	public float speed = 5.0f;

    private List<GunMode> gunModeList;
	public bool isHeldByPlayer;

	public static GunMode currentGunMode = GunMode.SHRINK;

	public enum GunMode
	{
		SHRINK = 1,
		GROW

    }

	;

	private void Start ()
	{
		rightArm = GameObject.Find ("RightArm");
		dialoguePanel = GameObject.Find ("Canvas").transform.Find ("DialoguePanel").gameObject;
        gunModeList = new List<GunMode>();
        gunModeList.AddRange((GunMode[])Enum.GetValues(typeof(GunMode)));
    }

    void Update ()
	{
        CheckInput();
	}
    
    void CheckInput()
    {
        if (GunInteract.isHeldByPlayer
            && dialoguePanel != null
            && !dialoguePanel.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector3 direction = target - transform.position;
                direction.Normalize();
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

                GameObject projectile = Instantiate(bulletModel, transform.position, rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
            }

            if (Input.GetMouseButtonDown(1))
            {
                if ((int)currentGunMode == gunModeList.Count)
                {
                    currentGunMode = gunModeList[0];
                }
                else
                {
                    currentGunMode = gunModeList[(int)currentGunMode];
                }
            }

            foreach (GunMode gunMode in gunModeList)
            {
                string gunModeString = ((int)gunMode).ToString();
                
                if (Input.GetKeyDown(gunModeString) 
                    || Input.GetKeyDown("[" + gunModeString + "]"))
                {
                    currentGunMode = gunMode;
                }
            }

        }
    }

}






