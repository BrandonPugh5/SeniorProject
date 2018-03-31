using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal_Detection : MonoBehaviour {

    public string sceneToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && SceneLoader.loadScene == false)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            SceneLoader.loadScene = true;
            SceneLoader.sceneToLoad = sceneToLoad;
        }
    }
}
