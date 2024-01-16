using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    // adjusts moving speed of the cannon
    [SerializeField] float multiplier = 0.5f;
    private UIHandler uiHandler;

    [SerializeField] GameObject cannonBallPrefab;
    [SerializeField] TextMeshProUGUI chargesText;
    private AudioSource fireSE;
    private AudioSource chargeSE;

    private Slider sliderComp;
    private bool autoFire = false;

    public float cannonForce = 0f;
    private int charges;

    void Start()
    {
        uiHandler = GameObject.FindGameObjectWithTag("UIHandler").GetComponent<UIHandler>();

        sliderComp = GameObject.Find("Slider").GetComponent<Slider>();
        sliderComp.value = cannonForce;
        chargeSE = sliderComp.GetComponent<AudioSource>();
        fireSE = GetComponent<AudioSource>();

        GameManager.Instance.SetChargesForLevel();
        charges = GameManager.Instance.charges;
        chargesText.text = "Charges: " + charges;
    }

    void Update()
    {
        // cannon rotating
        float verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(1, 0, 0), -verticalInput * multiplier);

        // if has charges -> can fire
        if (charges != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                cannonForce = 0;
                chargeSE.Play();
            }

            // check if holding space bar and cannon didn't fire automatically, due to maximum force
            if (Input.GetKey(KeyCode.Space) && !autoFire)
            {
                // increase force and update slider
                cannonForce += Time.deltaTime * 20;
                sliderComp.value = cannonForce;

                // when reached maximum force, then cannon automatically fires
                if (cannonForce >= 35)
                {
                    autoFire = true;
                    StartCoroutine(Fire());
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (!autoFire)
                    StartCoroutine(Fire());

                autoFire = false;
            }
        }
    }

    // fire with a line of 3 cannonballs
    IEnumerator Fire()
    {
        charges--;
        chargesText.text = "Charges: " + charges;

        Invoke("CheckIfFailed", 5);

        chargeSE.Stop(); 
        fireSE.Play();

        for (int i = 0; i < 3; i++)
        {
            Instantiate(cannonBallPrefab, transform.position, cannonBallPrefab.transform.rotation);
            // small pause between each fired cannonball
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void CheckIfFailed()
    {
        if (!GameManager.Instance.isVictory && charges == 0)
            uiHandler.ShowRestartButton();
    }
}
