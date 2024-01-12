using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientChange : MonoBehaviour
{
    [SerializeField] private Gradient gradient = null;
    [SerializeField] private Image image = null;
    [SerializeField] private GameObject slider;
    private Slider sliderScript;

    private void Awake()
    {
        image = GetComponent<Image>();
        sliderScript = slider.GetComponent<Slider>();
    }

    private void Update()
    {
        image.color = gradient.Evaluate(sliderScript.value / 35);
    }

}
