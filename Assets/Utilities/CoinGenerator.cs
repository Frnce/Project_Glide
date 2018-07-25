using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Utilities
{
    public class CoinGenerator : MonoBehaviour
    {
        [SerializeField] ObjectPooler objectPooler;
        [SerializeField] float distanceBetweenCoins;

        public void SpawnCoins(Vector3 startPosition)
        {
            GameObject gem1 = objectPooler.GetPooledObject();
            gem1.transform.position = startPosition;
            gem1.SetActive(true);

            GameObject gem2 = objectPooler.GetPooledObject();
            gem2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
            gem2.SetActive(true);

            GameObject gem3 = objectPooler.GetPooledObject();
            gem3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
            gem3.SetActive(true);
        }
    }

}