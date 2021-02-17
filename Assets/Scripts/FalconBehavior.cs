using System.Collections;
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
        
            var cannonPos = frontCannotRight.transform.position;
            var newPos = cannonPos + (frontCannotRight.transform.parent.forward * 2);

            DrawLine(cannonPos, newPos);
            DrawLine(frontCannotLeft.transform.position, frontCannotLeft.transform.position + (frontCannotLeft.transform.parent.forward * 2));
            DrawLine(frontCannotMiddle.transform.position, frontCannotMiddle.transform.position + (frontCannotMiddle.transform.parent.forward * 2));

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
