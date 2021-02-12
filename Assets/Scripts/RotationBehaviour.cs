using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;

    [SerializeField]
    private GameObject earth;

    [SerializeField]
    private GameObject moon;

    private Matrix4x4 earthMatrix;
    private Matrix4x4 sunMatrix;
    private Matrix4x4 moonMatrix;
    float i = 0;
    float j = 0;

    // Start is called before the first frame update
    void Start()
    {
        sunMatrix = T(0, 1, 0);
        sun.transform.position = sunMatrix.GetColumn(3);
        earthMatrix = sunMatrix;

    }

    // Update is called once per frame
    void Update()
    {
        earthMatrix = sunMatrix;
        earthMatrix = earthMatrix * S(2,0,4) * Ry((int) i * Mathf.Deg2Rad) * T(1, 0, 0);
        moonMatrix = T(earthMatrix.m03, earthMatrix.m13, earthMatrix.m23) * Ry((int) j * Mathf.Deg2Rad) * T(1, 0, 0);
        earth.transform.position = earthMatrix.GetColumn(3);
        moon.transform.position = moonMatrix.GetColumn(3);
        i += Time.deltaTime * 50;
        j += Time.deltaTime * 150;
    }

    /**************************************************************************/
    /************ CONVENIENCE FUNCTIONS FOR AFFINE TRANSFORMATIONS ************/
    /**************************************************************************/

    public static Matrix4x4 T(float x, float y, float z)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(1, 0, 0, x));
        m.SetRow(1, new Vector4(0, 1, 0, y));
        m.SetRow(2, new Vector4(0, 0, 1, z));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }

    public static Matrix4x4 Rx(float a)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(1, 0, 0, 0));
        m.SetRow(1, new Vector4(0, Mathf.Cos(a), -Mathf.Sin(a), 0));
        m.SetRow(2, new Vector4(0, Mathf.Sin(a), Mathf.Cos(a), 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }

    public static Matrix4x4 Ry(float a)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(Mathf.Cos(a), 0, Mathf.Sin(a), 0));
        m.SetRow(1, new Vector4(0, 1, 0, 0));
        m.SetRow(2, new Vector4(-Mathf.Sin(a), 0, Mathf.Cos(a),0 ));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }

    public static Matrix4x4 Rz(float a)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(Mathf.Cos(a), -Mathf.Sin(a), 0, 0));
        m.SetRow(1, new Vector4(Mathf.Sin(a), Mathf.Cos(a), 0, 0));
        m.SetRow(2, new Vector4(0, 0, 1, 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }


    public static Matrix4x4 S(float sx, float sy, float sz)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(sx, 0, 0, 0));
        m.SetRow(1, new Vector4(0, sy, 0, 0));
        m.SetRow(2, new Vector4(0, 0, sz, 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1) );

        return m;
    }
}
