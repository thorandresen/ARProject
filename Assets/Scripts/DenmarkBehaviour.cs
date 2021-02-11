using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenmarkBehaviour : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private TextMesh _country;
    private TextMesh _currentlyInfected;

    // Start is called before the first frame update
    void Start()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _ChangeColorOfSprite(Color color)
    {
        _sprite.color = color;
            
    }
}
