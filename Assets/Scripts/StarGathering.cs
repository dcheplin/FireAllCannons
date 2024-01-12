using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarGathering : MonoBehaviour
{
    private MeshRenderer meshRenderer;  
    private AudioSource gatheringSE;

    [SerializeField] TextMeshProUGUI starText;
    [SerializeField] ParticleSystem starParticles;

    public bool gathered = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        gatheringSE = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gathered && other.gameObject.CompareTag("Projectile"))
        {
            starParticles.Play();
            gatheringSE.Play();

            meshRenderer.material.SetColor("_Color", new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, 0.25f));
            
            starText.text = "Stars: 1 / 1";
            starText.color = Color.green;
            
            gathered = true;
        }
    }
}
