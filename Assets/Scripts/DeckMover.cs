using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMover : MonoBehaviour
{
    private float speed = 5;
    private float lowerBorder = -3;
    private float topBorder = 15;

    private float xPos;
    private float yPos;
    private float zPos;

    private void Awake()
    {
        xPos = transform.position.x;
        zPos = transform.position.z;
    }

    void FixedUpdate()
    {
        yPos = transform.position.y + Time.deltaTime * speed;

        transform.position = new Vector3(xPos, yPos, zPos);

        if (yPos >= topBorder || yPos <= lowerBorder)
            speed *= -1;
    }
}
