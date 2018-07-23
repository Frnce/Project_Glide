using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Characters
{
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody2D rb2d;
        PlayerController playerController;
        [SerializeField] float jumpTime = 0f;
        float jumpTimeCounter;

        bool inputStay;
        bool inputUp;

        Animator anim;
        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            playerController = GetComponent<PlayerController>();
            jumpTimeCounter = jumpTime;

            anim = FindObjectOfType<Animator>();
        }
        private void Update()
        {
            InitializeInputs();
            SetAnimations();
        }

        private void SetAnimations()
        {
            if (inputStay)
            {
                anim.SetBool("jumped", true);
            }
            if (rb2d.velocity.y < 0 && !playerController.GetIsGrounded())
            {
                anim.SetBool("isFalling", true);
            }
            if (playerController.GetIsGrounded())
            {
                anim.SetBool("jumped", false);
                anim.SetBool("isFalling", false);
            }
        }

        private void InitializeInputs()
        {
            inputStay = Input.GetMouseButton(0);
            inputUp = Input.GetMouseButtonUp(0);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            //TODO player movement can still be upgraded
            rb2d.velocity = new Vector2(playerController.GetMoveSpeed(), rb2d.velocity.y);
            PlayerJump();
        }

        private void PlayerJump()
        {
            //TODO Implement Mobile Controls
            if (inputStay)
            {
                if (playerController.GetIsGrounded())
                {
                    if (jumpTimeCounter > 0)
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x, playerController.GetJumpForce());
                        jumpTimeCounter -= Time.deltaTime;
                    }
                }
            }
            if (inputUp)
            {
                if (playerController.GetIsGrounded())
                {
                    jumpTimeCounter = 0;
                }
            }
            if (playerController.GetIsGrounded())
            {
                jumpTimeCounter = jumpTime;
            }
        }
    }

}