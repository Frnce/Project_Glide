using UnityEngine;
using Glide.Characters;

namespace Glide.Camera
{
    public class CameraController : MonoBehaviour
    {
        private PlayerController player;

        Vector3 lastPlayerPosition;
        float distanceToMove;
        // Use this for initialization
        void Start()
        {
            player = FindObjectOfType<PlayerController>();
            lastPlayerPosition = player.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            MoveCameraWithPlayer();
        }

        private void MoveCameraWithPlayer()
        {
            distanceToMove = player.transform.position.x - lastPlayerPosition.x;
            transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

            lastPlayerPosition = player.transform.position;
        }
    }

}