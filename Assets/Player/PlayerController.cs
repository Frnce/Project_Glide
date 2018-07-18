using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // Use this for initialization
        void Start()
        {
            speedMilestoneCount = speedIncreaseMilestone;
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
    }

}