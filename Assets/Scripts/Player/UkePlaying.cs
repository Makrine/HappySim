using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This class is used to play the uke and add money to the player every 5 seconds
/// </summary>
public class UkePlaying : MonoBehaviour
{
    // reference to the uke
    public GameObject Uke;
    public Button playUke;
    public PlayerInvenotry playerInventory;
    public Tutorial ukeTutorial;
    public CanvasGroup popup;
    public DoTweensManager coins;

    private Animator anim;
    private bool canPlayUke = false;
    private bool isPlayingUke = false;

    private float timePlayingUke = 0f;
    private bool popupShown = false;
    private TMPro.TMP_Text popupTxt;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        playUke.onClick.AddListener(() => PlayUke(!isPlayingUke));
        popupTxt = popup.GetComponentInChildren<TMPro.TMP_Text>();
    }

    private void Update()
    {
        if(isPlayingUke)
        {
            timePlayingUke += Time.deltaTime;

            // add money every 5 seconds
            if(timePlayingUke >= 5f)
            {
                playerInventory.AddMoney(10);
                timePlayingUke = 0f;
                
                if(!popupShown)
                {
                    popupShown = true;
                    popupTxt.text = "You are earning money! Keep playing to earn more";
                    StartCoroutine(Popup());
                }
                    
                coins.FadeOutUp();
                AudioManager.Instance.PlayAudio(AudioManager.Instance.coins);
            }
        }
        else
        {
            timePlayingUke = 0f;
        }
    }

    public void PlayUke(bool flag)
    {
        if (!canPlayUke && flag)
        {
            popupTxt.text = "Go to the fountain area and play there!";
            StartCoroutine(Popup());
            return;
        }

        Uke.SetActive(flag);
        anim.SetBool("Uke", flag);
        isPlayingUke = flag;
    }

    // if the player is in the uke playing area, they can play the uke
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UkePlayingArea"))
        {
            canPlayUke = true;
            StartCoroutine(ukeTutorial.UkeTutorial());
        }
    }

    // if the player leaves the uke playing area, they can no longer play the uke
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("UkePlayingArea"))
        {
            canPlayUke = false;
            popupShown = false;
        }
    }

    // show helpful popups
    IEnumerator Popup()
    {
        popup.alpha = 1;
        yield return new WaitForSeconds(3f);
        popup.alpha = 0;
    }
}
