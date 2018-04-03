using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndGrow : MonoBehaviour {

    
    public bool canOnlyGrow, canOnlyShrink;
    public int maxGrowHits, maxShrinkHits;
    public float growScale, shrinkScale;
    public ScaleDirection direction;

    [HideInInspector]
    public enum ScaleDirection
    {
        ALL_DIRECTIONS,
        UPWARDS,
        DOWNWARDS,
        LEFT,
        RIGHT
    }

    private void Start()
    {
        Vector2 position = transform.localPosition;
        Vector2 parentPosition = transform.parent.position;

        switch (direction)
        {
            case ScaleDirection.UPWARDS:  //change pivot of object to be at the bottom
                transform.localPosition = new Vector2(0, 0.5f);
                transform.parent.position = new Vector2(parentPosition.x, parentPosition.y - .5f);
                break;
            case ScaleDirection.DOWNWARDS:  //change pivot of object to be at the top
                transform.position = new Vector2(0, -0.5f);
                transform.parent.position = new Vector2(parentPosition.x, parentPosition.y + .5f);
                break;
            case ScaleDirection.LEFT:  //change pivot of object to be to the right
                transform.position = new Vector2(-0.5f, 0);
                transform.parent.position = new Vector2(parentPosition.x + 0.5f, parentPosition.y);
                break;
            case ScaleDirection.RIGHT:  //change pivot of object to be to the left
                transform.position = new Vector2(0.5f, 0);
                transform.parent.position = new Vector2(parentPosition.x - 0.5f, parentPosition.y);
                break;
        }
    }
}
