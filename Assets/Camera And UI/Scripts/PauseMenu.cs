using Glide.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Glide.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] string mainMenuLevel;
        [SerializeField] GameObject pauseMenu;
        public void PauseGame()
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        public void ResumeGame()
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
        public void RestartGame()
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            FindObjectOfType<GameManager>().Restart();
        }
        public void ReturnToMain()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(mainMenuLevel);
        }
    }
}