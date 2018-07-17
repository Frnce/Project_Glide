using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Characters
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 10f;
        [SerializeField] float JumpForce = 10f;
        [SerializeField] LayerMask whatIsGround;
        private bool isGrounded;
        Rigidbody2D rb2d;
        Collider2D myCollider;
        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            myCollider = GetComponent<Collider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckIfGrounded();
            //TODO player movement can still be upgraded
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, JumpForce);
            }
        }

        private void CheckIfGrounded()
        {
            isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        }
    }

}