using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Platforms
{
    public class FallingPlatform : MonoBehaviour
    {
        [SerializeField] float fallDelay = 0.5f;
        Rigidbody2D rb2d;
        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                StartCoroutine(Fall());
            }
        }
        IEnumerator Fall()
        {
            yield return new WaitForSeconds(fallDelay);
            rb2d.isKinematic = false;
            yield return 0;
        }
    }
}
