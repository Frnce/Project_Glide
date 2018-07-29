using UnityEngine;

namespace Glide.Utilities
{
    [System.Serializable]
    public class PlatformData
    {
        public ObjectPooler objectPools;
        //Consider using vector for varied position
        public float yGemPosition;
    }
    public class PlatformGenerator : MonoBehaviour
    {
        public PlatformData[] platformPoolers;
        [Space]
        [SerializeField] Transform generationPoint;

        float[] platformWidths;
        int selectedPlatform;

        CoinGenerator coinGenerator;
        [SerializeField] float randomGemThreshold;

        // Use this for initialization
        void Start()
        {
            InitializePooler();

            coinGenerator = FindObjectOfType<CoinGenerator>();
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
                platformWidths[i] = platformPoolers[i].objectPools.GetPooledObjectColliderSize();
            }
        }

        private void GeneratePlatforms()
        {
            if (transform.position.x < generationPoint.position.x)
            {
                selectedPlatform = Random.Range(0, platformPoolers.Length);

                transform.position = new Vector3(transform.position.x + (platformWidths[selectedPlatform] / 2), transform.position.y, transform.position.z);
                GameObject newPlatform = platformPoolers[selectedPlatform].objectPools.GetPooledObject();
                //newPlatform.transform.position = transform.position;
                newPlatform.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                newPlatform.SetActive(true);

                if (Random.Range(0f, 100f) < randomGemThreshold)
                {
                    coinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + platformPoolers[selectedPlatform].yGemPosition, transform.position.z));
                }

                transform.position = new Vector3(transform.position.x + (platformWidths[selectedPlatform] / 2), transform.position.y, transform.position.z);
            }
        }
    }

}