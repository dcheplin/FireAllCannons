using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyThis",2);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
