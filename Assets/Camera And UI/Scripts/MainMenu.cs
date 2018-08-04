using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Glide.UI
{
    public class MainMenu : MonoBehaviour
    {
        public string playGameLevel;
        public void PlayGame()
        {
            SceneManager.LoadScene(playGameLevel);
        }
        public void Settings()
        {
            //TODO create Settings 
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //show Yes or no , then exit;
            }
        }
    }

}