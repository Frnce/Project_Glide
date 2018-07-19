using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Characters
{
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody2D rb2d;
        PlayerController playerController;
        [SerializeField] float jumpTime;
        float jumpTimeCounter;
        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            playerController = GetComponent<PlayerController>();
            jumpTimeCounter = jumpTime;
        }
        private void Update()
        {
            
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (playerController.GetIsGrounded())
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, playerController.GetJumpForce());
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if(jumpTimeCounter > 0)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, playerController.GetJumpForce());
                    jumpTimeCounter -= Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
               jumpTimeCounter = 0;
            }
            if (playerController.GetIsGrounded())
            {
                jumpTimeCounter = jumpTime;
            }
        }
    }

}