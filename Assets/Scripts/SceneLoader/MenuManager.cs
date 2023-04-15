using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is used to manage the menu and settings as well
/// </summary>
public class MenuManager : MonoBehaviour
{
    public Button startOrMenu;
    public Button settings;
    public Button credits;

    public SceneLoader sceneLoader;

    public Button settingsClose;
    public Button creditsClose;
    public UIManager uiManagerSettings;
    public UIManager uiManagerMenu;
    public UIManager uiManagerCredits;

    public Sprite[] onOffButtons;
    public Button musicOnOff;
    public Button soundOnOff;

    private bool isSettingsOpen = false;
    private bool isCreditsOpen = false;

    private void Awake()
    {
        startOrMenu.onClick.AddListener(() => sceneLoader.LoadScene(Scene.Game));
        settings.onClick.AddListener(() => OpenPanel(true, uiManagerSettings));
        settingsClose.onClick.AddListener(() => OpenPanel(false, uiManagerSettings));
        credits.onClick.AddListener(() => OpenPanel(true, uiManagerCredits));
        creditsClose.onClick.AddListener(() => OpenPanel(false, uiManagerCredits));

        musicOnOff.onClick.AddListener(() => ToggleMusic(musicOnOff));
        soundOnOff.onClick.AddListener(() => ToggleMusic(soundOnOff));
    }
    
    /// <summary>
    /// Open or close a panel
    /// </summary>
    public void OpenPanel(bool flag, UIManager uiManager)
    {
        if(isSettingsOpen == flag)
            return;
        if(flag)
        {
            uiManagerMenu.GoLeft();
            uiManager.FadeInPanel();
            uiManager.canvasGroup.interactable = true;
            uiManager.canvasGroup.blocksRaycasts = true;
            isSettingsOpen = true;
        }
            
        else
        {
            uiManagerMenu.GoRight();
            uiManager.FadeOutPanel();
            uiManager.canvasGroup.interactable = false;
            uiManager.canvasGroup.blocksRaycasts = false;
            isSettingsOpen = false;
        }
           
    }


    /// <summary>
    /// Toggle music on/off and change the sprite of the button
    /// </summary>
    public void ToggleMusic(Button btn)
    {
        Image image = btn.GetComponent<Image>();
        var currentSprite = image.sprite;
        if(currentSprite == onOffButtons[0])
            image.sprite = onOffButtons[1];
        else
            image.sprite = onOffButtons[0];

    }

}
