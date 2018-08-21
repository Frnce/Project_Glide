using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Glide.Manager;

namespace Glide.UI
{
    public class DeathMenu : MonoBehaviour
    {
        public string mainMenuLevel;
        public string mainGameLevel;
        public void RestartGame()
        {
            //TODO For testing purposes
            FindObjectOfType<GameManager>().Restart();
            //SceneManager.LoadScene(mainGameLevel);
        }
        public void ReturnToMain()
        {
            SceneManager.LoadScene(mainMenuLevel);
        }
    }

}