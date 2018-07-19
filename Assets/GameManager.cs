using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Glide.Characters;
using Glide.Platforms;

namespace Glide.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] Transform platformGenerator;
        Vector3 platformStartPoint;
        [SerializeField] PlayerController playerController;
        Vector3 playerStartPoint;
        [Space]
        [SerializeField] float restartDelay = 0.5f;

        DestroyPlatforms[] platformsList;
        ScoreManager scoreManager;

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
            StartCoroutine("IRestartGame");
        }
        public IEnumerator IRestartGame()
        {
            scoreManager.GetScoreIncreasing(false);
            playerController.gameObject.SetActive(false);
            yield return new WaitForSeconds(restartDelay);

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

