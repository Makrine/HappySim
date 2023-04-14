using UnityEngine;
using DG.Tweening;

/// <summary>
/// This class is used to manage the UI animations with DoTween
/// </summary>
[System.Serializable]
public class UIManager
{
    public float fadeTime = 0.5f;
    public float scaleTime = 0.5f;
    public float posY = -1000f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;


    private Vector3 startPos = Vector3.zero;

    public void FadeInPopup()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localScale = Vector3.zero;
        rectTransform.DOScale(new Vector3(1f, 1f, 1f), scaleTime).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1f, fadeTime);
    }

    public void FadeOutPopup()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localScale = new Vector3(1f, 1f, 1f);
        rectTransform.DOScale(Vector3.zero, scaleTime).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0f, fadeTime);
    }

    public void FadeInPanel()
    {
        if(startPos == Vector3.zero)
            startPos = rectTransform.transform.localPosition;
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(startPos.x, posY, startPos.z);
        rectTransform.transform.DOLocalMoveY(startPos.y, fadeTime).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1f, fadeTime);
    }

    public void FadeOutPanel()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(startPos.x, startPos.y, startPos.z);
        rectTransform.transform.DOLocalMoveY(posY, fadeTime).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0f, fadeTime);
    }

}