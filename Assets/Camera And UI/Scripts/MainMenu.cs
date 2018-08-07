using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Glide.Characters;

namespace Glide.UI
{
    public class MainMenu : MonoBehaviour
    {
        public string playGameLevel;
        public float changeSceneDelay = 0.5f;

        PlayerController playerController;
        private void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
        }
        public void PlayGame()
        {
            Jump();
            StartCoroutine(ChangeScene());
        }

        private void Jump()
        {
            if (playerController.GetIsGrounded())
            {
                playerController.GetComponent<Rigidbody2D>().velocity = new Vector2(playerController.GetComponent<Rigidbody2D>().velocity.x, playerController.GetJumpForce());
            }
        }

        public void Settings()
        {
            //TODO create Settings 
        }
        public void Store()
        {
            //TODO create Store
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //show Yes or no , then exit;
            }
        }

        IEnumerator ChangeScene()
        {
            yield return new WaitForSeconds(changeSceneDelay);
            SceneManager.LoadScene(playGameLevel);
        }
    }

}