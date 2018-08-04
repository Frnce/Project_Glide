using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Glide.Characters;
using Glide.Platforms;
using Glide.UI;

namespace Glide.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] Transform platformGenerator;
        Vector3 platformStartPoint;
        [SerializeField] PlayerController playerController;
        Vector3 playerStartPoint;

        DestroyPlatforms[] platformsList;
        ScoreManager scoreManager;

        [SerializeField] DeathMenu deathMenu;

        // Use this for initialization
        void Start()
        {
            SetupStartPoints();

            scoreManager = FindObjectOfType<ScoreManager>();
        }

        private void SetupStartPoints()
        {
            platformStartPoint = platformGenerator.position;
            playerStartPoint = playerController.transform.position;
        }
        public void RestartGame()
        {
            scoreManager.GetScoreIncreasing(false);
            playerController.gameObject.SetActive(false);

            deathMenu.gameObject.SetActive(true);
        }
        public void Restart()
        {
            deathMenu.gameObject.SetActive(false);
            platformsList = FindObjectsOfType<DestroyPlatforms>();
            foreach (var item in platformsList)
            {
                item.gameObject.SetActive(false);
            }
            playerController.gameObject.SetActive(true);
            playerController.transform.position = playerStartPoint;
            platformGenerator.position = platformStartPoint;

            scoreManager.getScoreCount(0);
            scoreManager.GetScoreIncreasing(true);
        }
    }
}

