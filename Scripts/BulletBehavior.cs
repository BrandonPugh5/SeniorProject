using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    float lifetime = 1.0f;
    private Animator banim;
    public Transform eggposition;

    void OnCollisionEnter2D(Collision2D objectHit)
    {

        string hitTag = objectHit.gameObject.tag;
        ShrinkAndGrow shrinkAndGrow = objectHit.gameObject.GetComponent<ShrinkAndGrow>();
    

        if (hitTag == "Shootable" 
            && GunBehavior.currentGunMode == GunBehavior.GunMode.shrink 
            && !shrinkAndGrow.canOnlyGrow
            && shrinkAndGrow.maxShrinkHits > 0)
        {
            objectHit.transform.localScale *= shrinkAndGrow.shrinkScale;
            shrinkAndGrow.maxGrowHits++;
            shrinkAndGrow.maxShrinkHits--;
            shrinkAndGrow.canGrow = true;

            if (shrinkAndGrow.maxShrinkHits <= 0)
            {
                shrinkAndGrow.canShrink = false;
            }
        }
        else if (hitTag == "Shootable" 
            && GunBehavior.currentGunMode == GunBehavior.GunMode.grow
            && !shrinkAndGrow.canOnlyShrink
            && shrinkAndGrow.maxGrowHits > 0)
        {
            objectHit.transform.localScale *= shrinkAndGrow.growScale;
            shrinkAndGrow.maxGrowHits--;
            shrinkAndGrow.maxShrinkHits++;
            shrinkAndGrow.canShrink = true;

            if(shrinkAndGrow.maxGrowHits <= 0)
            {
                shrinkAndGrow.canGrow = false;
            }

            string name = objectHit.gameObject.name;

            if (name == "S Butcher 2")
            {
                GameObject.FindWithTag("Chicken").GetComponent<Animator>().SetBool("roll", true);
                banim = objectHit.gameObject.transform.Find("S Butcher Rig").GetComponent<Animator>();
                banim.SetBool("attack", true);

                GameObject.FindWithTag("Egg").GetComponent<Animator>().SetBool("lay", true);
                Destroy(objectHit.gameObject, 6f);
                Destroy(GameObject.FindWithTag("Egg").GetComponent<Animator>(), 2f);
            }

            if (name == "pan")
            {
                objectHit.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

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
