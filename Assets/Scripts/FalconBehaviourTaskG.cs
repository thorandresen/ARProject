using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconBehaviourTaskG : MonoBehaviour
{
    Matrix4x4 leftCannon;
    Matrix4x4 rightCannon;
    Matrix4x4 middleCannon;

    // Start is called before the first frame update
    void Start()
    {
        Matrix4x4 mat = gameObject.transform.worldToLocalMatrix;
        leftCannon = mat * RotationBehaviour.T(-0.11f, 0f, 0.658f);
        rightCannon = mat * RotationBehaviour.T(0.081f, 0f, 0.658f);
        middleCannon = mat * RotationBehaviour.T(0f, 0.212f, -0.123f);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DrawLine(leftCannon.GetColumn(3),gameObject.transform.forward);
            DrawLine(rightCannon.GetColumn(3), gameObject.transform.forward);
            DrawLine(middleCannon.GetColumn(3), gameObject.transform.forward);
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
        Destroy(myLine, Time.deltaTime*100);
    }

}
