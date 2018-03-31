using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private static SceneLoader Instance = null;
    public static string sceneToLoad;
   
    public GameObject loadingBarGameObject;
    public Slider loadingBarSlider;
    AsyncOperation async;
    public Text loadingText;

    public static bool loadScene = false;

    // Use this for initialization
    void Start()
    {
        loadingBarGameObject.SetActive(false);
    }
    
	
	void Update () {
		if(loadScene == true)
        {
            loadScene = false;
            StartCoroutine(ChangeScene(sceneToLoad));
            print("Loading Scene");
        }
	}

    IEnumerator ChangeScene(string sceneToLoad)
    {
        loadingBarGameObject.SetActive(true);
        float fadeTime = GameObject.Find("GameManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        async = SceneManager.LoadSceneAsync(sceneToLoad);
        async.allowSceneActivation = false;
        //async.allowSceneActivation = true;

        while (!async.isDone)
        {
            print("still loading");
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            print("progress is "+ progress);
            loadingBarSlider.transform.SetAsLastSibling();
            loadingBarSlider.value = progress;
            loadingText.text = progress * 100f + "%";
            if (progress == 1f)
            {
                loadingBarGameObject.SetActive(false);
                async.allowSceneActivation = true;

            }
           
            yield return null;
        }
    }
}
