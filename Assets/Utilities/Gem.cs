using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Glide.Manager;

namespace Glide.Utilities
{
    public class Gem : MonoBehaviour
    {
        [SerializeField] int ScorePoints = 1;
        ScoreManager scoreManager;
        // Use this for initialization
        void Start()
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                scoreManager.getCoinsScoreCount(ScorePoints);
            }
            gameObject.SetActive(false);
        }
    }

}
