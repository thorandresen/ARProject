using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleBehaviour : MonoBehaviour
{
    Renderer color;
    [SerializeField] private GameObject stripQuad;

  
    // Start is called before the first frame update
    void Start()
    {
        color = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var shuttleRight = gameObject.transform.right;
        var stripRight = stripQuad.transform.right;
        var shuttleForward = gameObject.transform.forward;
        var stripForward = stripQuad.transform.forward;
        var shuttleUp = gameObject.transform.up;
        var stripUp = stripQuad.transform.up;

        //var dotSum = Vector3.Dot(shuttleRight, stripRight) + Vector3.Dot(shuttleForward, stripForward);
        //var green = Mathf.Abs(dotSum * (255 / 2) + 127.5f);
        //var red = Mathf.Abs(255 - green);

        var counter = 0;
        if (Vector3.Dot(shuttleRight, stripRight)>0.9) {
            counter++;
        }
        if (Vector3.Dot(shuttleForward, stripForward) > 0.9)
        {
            counter++;
        }
        if (Vector3.Dot(shuttleUp, stripUp) > 0.9)
        {
            counter++;
        }
        Debug.Log(counter);
        switch (counter) {
            case 0:
                color.material.color = Color.red;
                break;
            case 3:
                color.material.color = Color.green;
                break;
            default:
                color.material.color = Color.yellow;
                break;
        }
        
    }

}
