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
        public void RestartGame()
        {
            FindObjectOfType<GameManager>().Restart();  
        }
        public void ReturnToMain()
        {
            SceneManager.LoadScene(mainMenuLevel);
        }
    }

}