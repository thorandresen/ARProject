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
        //Vector3 rotation = gameObject.transform.rotation.eulerAngles;
        //Matrix4x4 mat = gameObject.transform.worldToLocalMatrix;
        //leftCannon = mat * RotationBehaviour.Rx(rotation.x) * RotationBehaviour.Rx(rotation.y) * RotationBehaviour.Rx(rotation.z) * RotationBehaviour.T(-0.11f, 0f, 0.658f);
        //rightCannon = mat * RotationBehaviour.T(0.081f, 0f, 0.658f);
        //middleCannon = mat * RotationBehaviour.T(0f, 0.212f, -0.123f);
    }



    // Update is called once per frame
    void Update()
    {
        // Retrieve position and rotation of falcon.
        Vector3 rotation = gameObject.transform.rotation.eulerAngles;
        Matrix4x4 mat = gameObject.transform.worldToLocalMatrix;

        // Calculate position and rotation of cannons.
        leftCannon = mat * RotationBehaviour.Rx(rotation.x) * RotationBehaviour.Ry(rotation.y) * RotationBehaviour.Rz(rotation.z) * RotationBehaviour.T(-0.11f, 0f, 0.658f);
        rightCannon = mat * RotationBehaviour.Rx(rotation.x) * RotationBehaviour.Ry(rotation.y) * RotationBehaviour.Rz(rotation.z) * RotationBehaviour.T(0.081f, 0f, 0.658f);
        middleCannon = mat * RotationBehaviour.Rx(rotation.x) * RotationBehaviour.Ry(rotation.y) * RotationBehaviour.Rz(rotation.z) * RotationBehaviour.T(0f, 0.25f, -0.123f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Convert Vector4 to Vector3.
            Vector3 leftCannonVec3 = ToVector3(leftCannon.GetColumn(3));
            Vector3 rightCannonVec3 = ToVector3(rightCannon.GetColumn(3));
            Vector3 middleCannonVec3 = ToVector3(middleCannon.GetColumn(3));

            DrawLine(leftCannon.GetColumn(3), leftCannonVec3 + (gameObject.transform.forward * 2));
            DrawLine(rightCannon.GetColumn(3), rightCannonVec3 + (gameObject.transform.forward * 2));
            DrawLine(middleCannon.GetColumn(3), middleCannonVec3 + (gameObject.transform.forward * 2));
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

    public Vector3 ToVector3(Vector4 parent)
    {
        return new Vector3(parent.x, parent.y, parent.z);
    }
}
