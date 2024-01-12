using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallTrajectory : MonoBehaviour
{
    private GameObject cannon;
    private Rigidbody cannonBallRb;
    private AudioSource knockSE;

    // Start is called before the first frame update
    void Start()
    {
        cannon = GameObject.Find("cannon");
        PlayerController controller = cannon.GetComponent<PlayerController>();
        knockSE = GetComponent<AudioSource>();

        cannonBallRb = GetComponent<Rigidbody>();
        cannonBallRb.AddRelativeForce(controller.cannonForce * cannon.transform.forward, ForceMode.Impulse);
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
