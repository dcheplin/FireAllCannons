using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    private GameObject cannon;
    private Rigidbody cannonballRb;
    private AudioSource knockSE;

    void Start()
    {
        cannon = GameObject.FindGameObjectWithTag("Player");
        PlayerController controller = cannon.GetComponent<PlayerController>();
        knockSE = GetComponent<AudioSource>();

        cannonballRb = GetComponent<Rigidbody>();
        cannonballRb.AddRelativeForce(controller.cannonForce * cannon.transform.forward, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.CompareTag("Deck"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            knockSE.Play();
        }
    }
}
