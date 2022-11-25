using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneContoller : Singalton<LoadingSceneContoller>
{
    [SerializeField] private GameObject _loadingScreenObject;
    
    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
   
        _loadingScreenObject.SetActive(true);
        
        AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        while (!unloadOp.isDone)
        {
            yield return null;
        }

        
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        loadOp.allowSceneActivation = true;
        while (!loadOp.isDone)
        {
            yield return null;
        }
        
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        _loadingScreenObject.SetActive(false);
    }
}
