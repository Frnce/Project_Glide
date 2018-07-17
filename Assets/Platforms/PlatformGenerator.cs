using UnityEngine;

namespace Glide.Platforms
{
    public class PlatformGenerator : MonoBehaviour
    {
        [SerializeField] PlatformPooler[] platformPoolers;
        [SerializeField] Transform generationPoint;

        [SerializeField] float distanceBetweenMin = 0f;
        [SerializeField] float distanceBetweenMax = 3f;

        float distanceBetween = 0f;

        float[] platformWidths;
        int selectedPlatform;

        // Use this for initialization
        void Start()
        {
            InitializePooler();
        }
        // Update is called once per frame
        void Update()
        {
            GeneratePlatforms();
        }

        private void InitializePooler()
        {
            platformWidths = new float[platformPoolers.Length];

            for (int i = 0; i < platformPoolers.Length; i++)
            {
                platformWidths[i] = platformPoolers[i].GetPooledObjectColliderSize();
            }
        }

        private void GeneratePlatforms()
        {
            if (transform.position.x < generationPoint.position.x)
            {
                distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
                selectedPlatform = Random.Range(0, platformPoolers.Length);
                transform.position = new Vector3(transform.position.x + (platformWidths[selectedPlatform] / 2) + distanceBetween, transform.position.y, transform.position.z);
                GameObject newPlatform = platformPoolers[selectedPlatform].GetPooledObject();
                newPlatform.transform.position = transform.position;
                newPlatform.SetActive(true);

                transform.position = new Vector3(transform.position.x + (platformWidths[selectedPlatform] / 2), transform.position.y, transform.position.z);
            }
        }
    }

}