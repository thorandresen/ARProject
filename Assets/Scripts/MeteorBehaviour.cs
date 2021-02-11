using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem _exp;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HELLO");
    }

    // Update is called once per frame
    void Update()
    {
        // Get both vectors
        Vector3 x = transform.position;
        Vector3 y = GameObject.Find("Earth").transform.position;

        // Calculate distance
        float distance = Mathf.Sqrt(Mathf.Pow((x.x - y.x), 2) + Mathf.Pow((x.y - y.y),2) + Mathf.Pow((x.z - y.z),2));

        // Is collision?
        if (distance < 1.1f)
        {
            Debug.Log("Distance collision!");
            Explode();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Earth")
        {
            Debug.Log("Collision!!");
            Explode();
        }
    }

    void Explode()
    {
        _exp.gameObject.SetActive(true);
        _exp.Play();
        Destroy(gameObject,1f);
    }
}