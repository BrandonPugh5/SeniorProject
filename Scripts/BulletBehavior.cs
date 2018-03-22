using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    float lifetime = 1.0f;
    
    void OnCollisionEnter2D(Collision2D objectHit)
    {
        string hitTag = objectHit.gameObject.tag;
        ShrinkAndGrow shrinkAndGrow = objectHit.gameObject.GetComponent<ShrinkAndGrow>();
        

        if (hitTag == "Shootable" 
            && GunBehavior.currentGunMode == GunBehavior.GunMode.shrink 
            && shrinkAndGrow.canShrink)
        {
            objectHit.transform.localScale *= shrinkAndGrow.shrinkAmount;
            shrinkAndGrow.currentCount--;
            shrinkAndGrow.canGrow = true;
            if (shrinkAndGrow.currentCount <= -1*shrinkAndGrow.maxCount)
            {
                shrinkAndGrow.canShrink = false;
            }
        }
        else if (hitTag == "Shootable" 
            && GunBehavior.currentGunMode == GunBehavior.GunMode.grow
            && shrinkAndGrow.canGrow)
        {
            objectHit.transform.localScale *= shrinkAndGrow.growAmount;
            shrinkAndGrow.currentCount++;
            shrinkAndGrow.canShrink = true;
            if(shrinkAndGrow.currentCount >= shrinkAndGrow.maxCount)
            {
                shrinkAndGrow.canGrow = false;
            }
        }
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        lifetime -= 0.7f * Time.deltaTime;
        if (lifetime <= 0.0)
            Destroy(gameObject);

    }
}
