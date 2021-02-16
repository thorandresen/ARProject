using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmonien : MonoBehaviour
{
    [SerializeField] private GameObject field;
    private Vector3 invMat;
    private string text = "Please approach the landing strip";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Matrix4x4 mat = gameObject.transform.localToWorldMatrix;
        invMat = field.transform.worldToLocalMatrix.MultiplyPoint(new Vector3(mat.m03, mat.m13, mat.m23));

        if((invMat.x < 0f && invMat.x > -2f) && (invMat.y < 0f && invMat.y > -4f) && (invMat.z < 4f && invMat.z > 0f))
        {
            text = "Prepare to land";
        } else
        {
            text = "Please approach the landing strip";
        }
    }

    private void OnGUI()
    {
        // values might need to be adjusted
        
        GUI.skin.label.fontSize = 30;
        GUI.color = Color.red;
        GUI.Label(new Rect(10, 10, 1000, 300), $"Local position: {invMat.x}, {invMat.y}, {invMat.z}");
        GUI.Label(new Rect(10, 50, 1000, 300), $"Local position: {text}");
    }

}
