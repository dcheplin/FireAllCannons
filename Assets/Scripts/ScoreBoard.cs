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

    //private ScoreCounter scoreCounterScript;
    private AudioSource fireworkAudio;
    private float zLeftBorder = 0;
    private float zRightBorder = 30;
    private float yTopBorder = 16;
    private float yBottomBorder = 0;

    void Start()
    {
        fireworkAudio = GetComponent<AudioSource>();
    }

    public void ShowScoreBoard()
    {
        //TODO: add score board and score counting
        //totalScoreText.text = "Victory!\nTotal score: " + "" + "\n\n\nFor questions, suggestions\nand more levels: dcheplin@gmail.com\n\nDenis Cheplin, Israel, December 2023";
        totalScoreText.text = "Victory!\n\nFor questions, suggestions\nand more levels: dcheplin@gmail.com\n\nDenis Cheplin, Israel, December 2023";
        InvokeRepeating("SpawnFireworks", 0, 0.3f);
        //GameObject.Find("MusicAudioManager").GetComponent<AudioSource>().Stop();
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
