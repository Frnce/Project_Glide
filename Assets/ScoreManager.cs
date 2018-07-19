using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Glide.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] Text scoreText;
        [SerializeField] Text collectedCoinsText;

        [SerializeField] float scoreCount;
        [SerializeField] float collectedCoinsCount;

        [SerializeField] float pointsPerSecond;
        bool scoreIncreasing;
        // Use this for initialization
        private void Start()
        {
            scoreIncreasing = true;
        }
        public bool GetScoreIncreasing(bool value)
        {
            return scoreIncreasing = value;
        }
        public float getScoreCount(float score)
        {
            return scoreCount = score;
        }
        // Update is called once per frame
        void Update()
        {
            AddScore();
            ShowScoreText();
            //TODO implement collected Coins;
        }

        private void AddScore()
        {
            if (scoreIncreasing)
            {
                scoreCount += pointsPerSecond * Time.deltaTime;
            }
        }

        private void ShowScoreText()
        {
            scoreText.text = Mathf.Round(scoreCount).ToString("0000000");
        }
    }

}