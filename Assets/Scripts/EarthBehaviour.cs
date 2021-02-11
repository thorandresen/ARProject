﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(GameObject.Find("Sun").transform.position, new Vector3(0, 1, 0), 50 * Time.deltaTime);
        transform.Rotate(0, 1, 0);
    }
}
