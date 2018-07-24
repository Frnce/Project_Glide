using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Platforms
{
    public class ClosingPlatform : MonoBehaviour
    {
        [SerializeField] float moveVelocity = 12f;

        [SerializeField] Transform goingUpPlatform;
        [SerializeField] Transform goingDownPlatform;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                goingUpPlatform.GetComponent<Rigidbody2D>().velocity = new Vector2(goingUpPlatform.localPosition.x, moveVelocity);
                goingDownPlatform.GetComponent<Rigidbody2D>().velocity = new Vector2(goingDownPlatform.localPosition.x, -moveVelocity);
            }
        }
    }

}