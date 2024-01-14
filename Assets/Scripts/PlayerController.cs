using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    [SerializeField] float multiplier = 0.5f;
    [SerializeField] GameObject cannonBallPrefab;
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject counter;
    [SerializeField] TextMeshProUGUI chargesText;
    [SerializeField] AudioSource fireSE;
    [SerializeField] AudioSource chargeSE;

    private GameManager gameManagerScript;
    private Counter counterScript;
    private Slider sliderComp;
    private bool autoFire = false;

    public float cannonForce = 0f;
    public int charges = 3;

    void Start()
    {
        sliderComp = GameObject.Find("Slider").GetComponent<Slider>();
        sliderComp.value = cannonForce;
        chargeSE = sliderComp.GetComponent<AudioSource>();

        gameManagerScript = gameManager.GetComponent<GameManager>();
        fireSE = GetComponent<AudioSource>();

        charges = gameManagerScript.GetAmountOfCharges();
        chargesText.text = "Charges: " + charges;

        counterScript = counter.GetComponent<Counter>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(new Vector3(1, 0, 0), -verticalInput * multiplier);

        if (charges != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                cannonForce = 0;
                chargeSE.Play();
            }

            if (Input.GetKey(KeyCode.Space) && !autoFire)
            {
                cannonForce += Time.deltaTime * 20;
                sliderComp.value = cannonForce;

                if (cannonForce >= 35)
                {
                    autoFire = true;
                    charges--;
                    chargesText.text = "Charges: " + charges;
                    chargeSE.Stop();

                    StartCoroutine(Fire());
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (!autoFire)
                {
                    charges--;
                    chargesText.text = "Charges: " + charges;
                    chargeSE.Stop();

                    StartCoroutine(Fire());
                }
                else
                {
                    autoFire = false;
                }
            }
        }

        if (counterScript.count < counterScript.levelGoal && charges == 0)
        {
            Invoke("ShowRestartButton", 4);

        }
        else if (counterScript.count >= counterScript.levelGoal)
        {
            Invoke("ShowNextLevelButton", 1.5f);
        }


    }



    IEnumerator Fire()
    {
        fireSE.Play();

        for (int i = 0; i < 3; i++)
        {
            Instantiate(cannonBallPrefab, transform.position, cannonBallPrefab.transform.rotation);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
