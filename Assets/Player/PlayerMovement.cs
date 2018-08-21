using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Characters
{
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody2D rb2d;
        PlayerController playerController;

        bool input;

        Animator anim;
        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            playerController = GetComponent<PlayerController>();

            anim = FindObjectOfType<Animator>();
        }
        private void Update()
        {
            InitializeInputs();
            SetAnimations();
        }

        private void SetAnimations()
        {
            if (!playerController.GetIsGrounded())
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
            input = Input.GetMouseButton(0);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            rb2d.velocity = new Vector2(playerController.GetMoveSpeed(), rb2d.velocity.y);
            PlayerJump();
        }

        private void PlayerJump()
        {
            if (playerController.GetIsGrounded())
            {
                if (input)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, playerController.GetJumpForce());
                }
            }
        }
    }

}