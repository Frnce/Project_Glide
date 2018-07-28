using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Platforms
{
    public class ClosingPlatform : MonoBehaviour
    {
        [SerializeField] Transform up;
        [SerializeField] Transform down;
        [SerializeField] Transform platform;
        [SerializeField] float velocity = 2f;

        bool isTriggered = false;
        bool hasBeenUsed = false;

        Vector3 upDefault;
        Vector3 downDefault;
        private void Start()
        {
            upDefault = up.localPosition;
            downDefault = down.localPosition;
        }
        private void FixedUpdate()
        {
            if (isTriggered && hasBeenUsed)
            {
                up.GetComponent<Rigidbody2D>().MovePosition(up.GetComponent<Rigidbody2D>().position + Vector2.up * velocity * Time.fixedDeltaTime);
                down.GetComponent<Rigidbody2D>().MovePosition(down.GetComponent<Rigidbody2D>().position + -Vector2.up * velocity * Time.fixedDeltaTime);
            }
            else
            {
                up.localPosition = upDefault;
                down.localPosition = downDefault;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isTriggered = true;
                hasBeenUsed = true;
            }
        }
        private void OnEnable()
        {
            Physics2D.IgnoreCollision(up.GetComponent<Collider2D>(), platform.GetComponent<Collider2D>());
        }
        private void OnDisable()
        {
            isTriggered = false;
            hasBeenUsed = false;
        }
    }

}