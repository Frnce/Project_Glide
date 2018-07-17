﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glide.Platforms
{
    public class DestroyPlatforms : MonoBehaviour
    {
        GameObject platformDestructionPoint;
        // Use this for initialization
        void Start()
        {
            platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
        }

        // Update is called once per frame
        void Update()
        {
            if(transform.position.x < platformDestructionPoint.transform.position.x)
            {
                gameObject.SetActive(false);
            }
        }
    }

}