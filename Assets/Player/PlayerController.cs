using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Glide.Manager;

namespace Glide.Characters
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 10f;
        [SerializeField] float jumpForce = 10f;
        [Header("GroundDetection")]
        [SerializeField] LayerMask whatIsGround;
        [SerializeField] Transform groundCheck;
        [SerializeField] float groundRadius = 0.1f;
        [Space]
        [SerializeField] float speedIncreaseMilestone = 10f;
        [SerializeField] float speedMultiplier = 5f;
        private bool isGrounded;
        float speedMilestoneCount;

        float moveSpeedStore;
        float speedMilestoneCountStore;
        float speedIncreaseMilestoneStore;

        GameManager gameManager;
        // Use this for initialization
        void Start()
        {
            InitializeVariables();
            gameManager = FindObjectOfType<GameManager>();
        }

        private void InitializeVariables()
        {
            speedMilestoneCount = speedIncreaseMilestone;

            moveSpeedStore = moveSpeed;
            speedMilestoneCountStore = speedMilestoneCount;
            speedIncreaseMilestoneStore = speedIncreaseMilestone;
        }

        public float GetMoveSpeed()
        {
            return moveSpeed;
        }
        public float GetJumpForce()
        {
            return jumpForce;
        }
        public bool GetIsGrounded()
        {
            return isGrounded;
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            CheckIfGrounded();
            SpeedMultiplier();
        }

        private void SpeedMultiplier()
        {
            if (transform.position.x > speedMilestoneCount)
            {
                speedMilestoneCount += speedIncreaseMilestone;

                speedIncreaseMilestone *= speedMultiplier;
                moveSpeed *= speedMultiplier;
            }
        }

        private void CheckIfGrounded()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("KillBox"))
            {
                gameManager.RestartGame();
                ResetPlayerAttributes();
            }
        }

        private void ResetPlayerAttributes()
        {
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }

}