using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GoingNextScene : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;


    private PlayerContorller _player;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            LoadingSceneContoller.instance.LoadNextScene(_nextSceneName);
        }
    }
}
