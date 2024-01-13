using System.Collections.Generic;
using UnityEngine;

public class CurvedArrowSwitcher : MonoBehaviour
{
    private int arrowAnimation = 0;

    [SerializeField] List<GameObject> TutorialTextsList = new List<GameObject>(); 
    [SerializeField] Animator arrowAnimator;
    [SerializeField] GameObject exitTutorialButton;

    public void OnButtonClick()
    {
        arrowAnimation++;
        arrowAnimator.SetInteger("int_Tutorial", arrowAnimation);
       
        TutorialTextsList[arrowAnimation - 1].SetActive(false);     
        TutorialTextsList[arrowAnimation].SetActive(true);

        if (arrowAnimation >= 6)
        {
            arrowAnimation = 0;
            exitTutorialButton.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
