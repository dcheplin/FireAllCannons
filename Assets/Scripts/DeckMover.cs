using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMover : MonoBehaviour
{
    public float speed = 5;
    public float lowerBordeer = -3;
    public float topBorder = 15;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, (transform.position.y + Time.deltaTime * speed), transform.position.z);

        if (transform.position.y >= topBorder || transform.position.y <= lowerBordeer)
        {
            speed *= -1;
        }

    }
}
