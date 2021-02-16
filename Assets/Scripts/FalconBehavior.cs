﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconBehavior : MonoBehaviour
{

    [SerializeField] private GameObject frontCannotRight;
    [SerializeField] private GameObject frontCannotLeft;
    [SerializeField] private GameObject frontCannotMiddle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            frontCannotRight.transform.rotation = Quaternion.AngleAxis(-45, frontCannotRight.transform.parent.forward);
            DrawLine(frontCannotRight.transform.position, Vector3.Scale(frontCannotRight.transform.position, frontCannotRight.transform.parent.forward)*2);

            DrawLine(frontCannotLeft.transform.position, Vector3.Scale(frontCannotLeft.transform.position, frontCannotLeft.transform.forward) * 2);
            //DrawLine(frontCannotMiddle.transform.position, frontCannotMiddle.transform.parent.forward);

            RaycastHit hit;
            if (Physics.Raycast(frontCannotRight.transform.position, frontCannotRight.transform.parent.forward,out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    void DrawLine(Vector3 start, Vector3 end, float lineWidth = 0.01f)
    {
        GameObject myLine = new GameObject();
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        Material material = new Material(Shader.Find("Transparent/Diffuse"));
        material.color = Color.red;
        lr.material = material;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        Destroy(myLine, Time.deltaTime*50);
    }


}
