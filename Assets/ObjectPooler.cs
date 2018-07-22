using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Utilities
{
    public class ObjectPooler : MonoBehaviour
    {
        [SerializeField] GameObject pooledObject;
        [SerializeField] int pooledAmount;

        List<GameObject> pooledObjects;
        // Use this for initialization
        public float GetPooledObjectColliderSize()
        {
            return pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        void Start()
        {
            pooledObjects = new List<GameObject>();
            InitializePooledObjects();
        }

        private void InitializePooledObjects()
        {
            for (int i = 0; i < pooledAmount; i++)
            {
                InstantiatePlatforms();
            }
        }

        private void InstantiatePlatforms()
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }
    }

}