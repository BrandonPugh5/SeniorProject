using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public string sceneToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && SceneLoader.loadScene == false)
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());  //Might not work properly!!!!!
            SceneLoader.loadScene = true;
            SceneLoader.sceneToLoad = sceneToLoad;
        }
    }


}
