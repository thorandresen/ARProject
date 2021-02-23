using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment21c : MonoBehaviour
{
    [SerializeField] private GameObject Ox;
    [SerializeField] private GameObject As;
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    bool towardsAs = false;
    // Update is called once per frame
    void Update()
    {
        pos1 = Ox.transform.position;
        pos2 = As.transform.position;

        if(Mathf.Abs(transform.position.x - pos2.x) < 1 && Mathf.Abs(transform.position.y - pos2.y) < 1 && Mathf.Abs(transform.position.z - pos2.z) < 1)
        {
            towardsAs = true;
        } else if (Mathf.Abs(transform.position.x - pos1.x) < 1 && Mathf.Abs(transform.position.y - pos1.y) < 1 && Mathf.Abs(transform.position.z - pos1.z) < 1)
        {
            towardsAs = false;
        }
        
        if(towardsAs)
        {
            transform.LookAt(pos1);
        } else
        {
            transform.LookAt(pos2);
        }
        
        transform.rotation *= Quaternion.Euler(90, 0, 0);
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time* speed, 1.0f));
     }
}
