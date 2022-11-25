using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneContoller : MonoBehaviour
{
        public void LoadScene(string scenename)
        {
            SceneManager.LoadScene(scenename);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
}
