using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initializer1 : MonoBehaviour
{
    private const string LOADING_SCREEN_NAME = "Gamplaymanager";

    private void Awake()
    {
        Scene loadingScreenScene = SceneManager.GetSceneByName(LOADING_SCREEN_NAME);
        // check if the scene is not loaded yet
        if (loadingScreenScene == null || !loadingScreenScene.isLoaded)
        {
            SceneManager.LoadScene(LOADING_SCREEN_NAME, LoadSceneMode.Additive);
        }
    }
}
