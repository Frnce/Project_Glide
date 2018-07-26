using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Platforms
{
    public class ClosingPlatform : MonoBehaviour
    {
        [SerializeField] Transform Up;
        [SerializeField] Transform Down;
        [SerializeField] float velocity = 2f;

        bool isTriggered = false;
        private void FixedUpdate()
        {
            if (isTriggered)
            {
                Up.GetComponent<Rigidbody2D>().MovePosition(Up.GetComponent<Rigidbody2D>().position + Vector2.up * velocity * Time.fixedDeltaTime);
                Down.GetComponent<Rigidbody2D>().MovePosition(Down.GetComponent<Rigidbody2D>().position + -Vector2.up * velocity * Time.fixedDeltaTime);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Collider2D>().CompareTag("Player"))
            {
                isTriggered = true;
            }
        }
    }

}