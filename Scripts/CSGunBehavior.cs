using UnityEngine;
using System;
using System.Collections.Generic;

public class GunBehavior : MonoBehaviour
{

	public GameObject bulletModel;
	public GameObject gun;
	private GameObject rightArm;
	private GameObject dialoguePanel;
	public float speed = 5.0f;

    public List<GunMode> gunModeList;
	public bool isHeldByPlayer;

	public static GunMode currentGunMode = GunMode.shrink;

	public enum GunMode
	{
		shrink = 1,
		grow

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
        print(currentGunMode);
        if (GunInteract.isHeldByPlayer
            && dialoguePanel != null
            && !dialoguePanel.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector3 direction = target - gun.transform.position;
                direction.Normalize();
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

                GameObject projectile = Instantiate(bulletModel, gun.transform.position, rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
            }

            if (Input.GetMouseButtonDown(1))
            {
                if ((int)currentGunMode == gunModeList.Count - 1)
                {
                    currentGunMode = gunModeList[0];
                }
                else
                {
                    currentGunMode = gunModeList[(int)currentGunMode + 1];
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






