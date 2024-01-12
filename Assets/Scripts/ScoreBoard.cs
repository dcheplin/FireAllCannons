using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> fireworksPrefabs;
    [SerializeField] TextMeshProUGUI totalScoreText;
    [SerializeField] Image totalScoreImage;

    private Button button;
    private ScoreCounter scoreCounterScript;
    private AudioSource fireworkAudio;
    private float zLeftBorder = 0;
    private float zRightBorder = 30;
    private float yTopBorder = 16;
    private float yBottomBorder = 0;
    private bool victory;

    // Start is called before the first frame update
    void Start()
    {
        victory = false;

        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        fireworkAudio = GetComponent<AudioSource>();

        scoreCounterScript = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
    }

    void OnButtonClick()
    {
        if (!victory)
        {
            victory = true;

            totalScoreImage.gameObject.SetActive(true);
            totalScoreText.text = "Victory!\nTotal score: " + scoreCounterScript.totalScore + "\n\n\nFor questions, suggestions\nand more levels: dcheplin@gmail.com\n\nDenis Cheplin, Israel, December 2023";
            InvokeRepeating("SpawnFireworks", 0, 0.3f);
            GameObject.Find("AudioManager").GetComponent<AudioSource>().Stop();
        }   
    }

    void SpawnFireworks()
    {
        Invoke("SpawnInRandom", Random.Range(0.1f, 1.5f));
    }

    void SpawnInRandom()
    {
        int fireworkIndex = Random.Range(0, fireworksPrefabs.Count);
        Vector3 spawnPos = new Vector3(0, Random.Range(yBottomBorder, yTopBorder), Random.Range(zLeftBorder, zRightBorder));
        
        Instantiate(fireworksPrefabs[fireworkIndex], spawnPos, fireworksPrefabs[fireworkIndex].transform.rotation);
        fireworkAudio.Play();
    }

}
