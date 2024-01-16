using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    private Dictionary<string, AudioClip> audioSources = new Dictionary<string, AudioClip>();
    [SerializeField] AudioClip fireSE;
    [SerializeField] AudioClip chargingSE;
    //[SerializeField] AudioClip starGatheringSE;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        audioSources.Add("Fire", fireSE);
        audioSources.Add("Charging", chargingSE);
    }

    public AudioClip GetSE(string nameOfClip)
    {
        return audioSources[nameOfClip];
    }



}
