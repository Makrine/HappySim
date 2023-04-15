using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public float waitTillTutorial = 0.5f;
    public float waitTillClose = 3f;
    public Button close;
    public DoTweensManager dotweenManager = new();
    
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
        yield return new WaitForSeconds(waitTillClose);
        if(dotweenManager.canvasGroup.alpha == 1)
        {
            dotweenManager.FadeOutPopup();
            dotweenManager.canvasGroup.interactable = false;
            dotweenManager.canvasGroup.blocksRaycasts = false;
        }
        
    }
}