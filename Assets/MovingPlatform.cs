using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform Up;
    [SerializeField] Transform Down;
    [SerializeField] float velocity;

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
