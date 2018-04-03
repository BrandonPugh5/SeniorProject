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
    
        if(hitTag == "Shootable")
        {
            bool canShrink = GunBehavior.currentGunMode == GunBehavior.GunMode.SHRINK
                && !shrinkAndGrow.canOnlyGrow
                && shrinkAndGrow.maxShrinkHits > 0;

            bool canGrow = GunBehavior.currentGunMode == GunBehavior.GunMode.GROW
                 && !shrinkAndGrow.canOnlyShrink
                 && shrinkAndGrow.maxGrowHits > 0;

            Transform parentTransform = objectHit.transform.parent;

            if (canShrink)
            {
                Shrink(objectHit.transform, shrinkAndGrow.direction, shrinkAndGrow.shrinkScale);
                shrinkAndGrow.maxGrowHits++;
                shrinkAndGrow.maxShrinkHits--;                
            }

            else if (canGrow)
            {
                Grow(objectHit.transform, shrinkAndGrow.direction, shrinkAndGrow.growScale);
                shrinkAndGrow.maxGrowHits--;
                shrinkAndGrow.maxShrinkHits++;
                

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
        }

        Destroy(gameObject);
    }
	
    void Shrink(Transform objectToShrink, ShrinkAndGrow.ScaleDirection direction, float shrinkScale)
    {
        Transform parentTransform = objectToShrink.parent;

        if (direction == ShrinkAndGrow.ScaleDirection.LEFT
            || direction == ShrinkAndGrow.ScaleDirection.RIGHT)
        {
            Vector2 scale = new Vector2(parentTransform.localScale.x * shrinkScale, parentTransform.localScale.y);
            parentTransform.localScale = scale;
        }
        else if (direction == ShrinkAndGrow.ScaleDirection.UPWARDS
            || direction == ShrinkAndGrow.ScaleDirection.DOWNWARDS)
        {
            Vector2 scale = new Vector2(parentTransform.localScale.x, parentTransform.localScale.y * shrinkScale);
            parentTransform.localScale = scale;
        }
        else
        {
            objectToShrink.localScale *= shrinkScale;
        }
    }

    void Grow(Transform objectToShrink, ShrinkAndGrow.ScaleDirection direction, float growScale)
    {
        Transform parentTransform = objectToShrink.parent;

        if (direction == ShrinkAndGrow.ScaleDirection.LEFT
            || direction == ShrinkAndGrow.ScaleDirection.RIGHT)
        {
            Vector2 scale = new Vector2(parentTransform.localScale.x * growScale, parentTransform.localScale.y);
            parentTransform.localScale = scale;
        }
        else if (direction == ShrinkAndGrow.ScaleDirection.UPWARDS
            || direction == ShrinkAndGrow.ScaleDirection.DOWNWARDS)
        {
            Vector2 scale = new Vector2(parentTransform.localScale.x, parentTransform.localScale.y * growScale);
            parentTransform.localScale = scale;
        }
        else
        {
            objectToShrink.localScale *= growScale;
        }
    }

	// Update is called once per frame
	void Update () {

        lifetime -= 0.7f * Time.deltaTime;
        if (lifetime <= 0.0)
            Destroy(gameObject);

    }
}
