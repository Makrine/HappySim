using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public float waitTillTutorial = 0.5f;
    public float waitTillClose = 3f;
    public float ukeTutorialFadeTime = 6f;
    public Button close;
    public DoTweensManager dotweenManager = new();
    public DoTweensManager dotweenManagerUke = new();
    
    private void Start()
    {
        close.onClick.AddListener(() => dotweenManager.FadeOutPopup());
        StartCoroutine(StartTutorial());
    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(waitTillTutorial);
        dotweenManager.FadeInPopup();
        dotweenManager.canvasGroup.interactable = true;
        dotweenManager.canvasGroup.blocksRaycasts = true;
        
    }

    public IEnumerator UkeTutorial()
    {
        dotweenManagerUke.FadeInPopup(); 
        dotweenManagerUke.canvasGroup.interactable = true;
        dotweenManagerUke.canvasGroup.blocksRaycasts = true;

        yield return new WaitForSeconds(ukeTutorialFadeTime);
        dotweenManagerUke.FadeOutPopup();
        dotweenManagerUke.canvasGroup.interactable = false;
        dotweenManagerUke.canvasGroup.blocksRaycasts = false;
    }
}
