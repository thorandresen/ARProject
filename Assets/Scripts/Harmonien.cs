using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmonien : MonoBehaviour
{
    [SerializeField] private GameObject field;
    private Vector3 invMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Matrix4x4 mat = gameObject.transform.localToWorldMatrix;
        invMat = field.transform.worldToLocalMatrix.MultiplyPoint(new Vector3(mat.m03, mat.m13, mat.m23));
    }

    private void OnGUI()
    {
        // values might need to be adjusted
        
        GUI.skin.label.fontSize = 30;
        GUI.color = Color.red;
        GUI.Label(new Rect(10, 10, 1000, 300), $"Local position: {invMat.x}, {invMat.y}, {invMat.z}");
    }

}
