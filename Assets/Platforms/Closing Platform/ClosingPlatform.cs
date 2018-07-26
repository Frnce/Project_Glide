using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Platforms
{
    public class ClosingPlatform : MonoBehaviour
    {
        [SerializeField] Transform up;
        [SerializeField] Transform down;
        [SerializeField] float velocity = 2f;

        bool isTriggered = false;

        private void FixedUpdate()
        {
            if (isTriggered)
            {
                up.GetComponent<Rigidbody2D>().MovePosition(up.GetComponent<Rigidbody2D>().position + Vector2.up * velocity * Time.fixedDeltaTime);
                down.GetComponent<Rigidbody2D>().MovePosition(down.GetComponent<Rigidbody2D>().position + -Vector2.up * velocity * Time.fixedDeltaTime);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isTriggered = true;
            }
        }
    }

}