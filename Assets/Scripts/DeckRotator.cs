using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckRotator : MonoBehaviour
{
    public float rotSpeed = 30;

    void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime * rotSpeed, 0, 0));    
    }
}
