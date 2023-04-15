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
    public Button exit;

    [HideInInspector]
    public SceneLoader sceneLoader;

    public Button settingsClose;
    public Button creditsClose;
    public DoTweensManager uiManagerSettings;
    public DoTweensManager uiManagerMenu;
    public DoTweensManager uiManagerCredits;

    public Sprite[] onOffButtons;
    public Button musicOnOff;
    public Button soundOnOff;

    private bool isSettingsOpen = false;
    private bool isCreditsOpen = false;

    private bool isGameScene = false;

    private void Start()
    {
        sceneLoader = GetComponentInParent<SceneLoader>();
        exit.onClick.AddListener(() => GameManager.Instance.ExitGame());
        startOrMenu.onClick.AddListener(LoadScene);
        settings.onClick.AddListener(() => OpenPanel(true, uiManagerSettings, ref isSettingsOpen));
        settingsClose.onClick.AddListener(() => OpenPanel(false, uiManagerSettings, ref isSettingsOpen));
        credits.onClick.AddListener(() => OpenPanel(true, uiManagerCredits, ref isCreditsOpen));
        creditsClose.onClick.AddListener(() => OpenPanel(false, uiManagerCredits, ref isCreditsOpen));

        musicOnOff.onClick.AddListener(() => ToggleMusic(musicOnOff));
        soundOnOff.onClick.AddListener(() => ToggleMusic(soundOnOff));
    }

    /// <summary>
    /// Load the scene
    /// </summary>
    private void LoadScene()
    {
        if(isGameScene)
        {
            sceneLoader.LoadScene(Scene.Menu);
        }
        else
        {
            sceneLoader.LoadScene(Scene.Game);
        }
        GameManager.Instance.PauseGame(false);
    }
    
    /// <summary>
    /// Open or close a panel
    /// </summary>
    public void OpenPanel(bool flag, DoTweensManager uiManager, ref bool isPanelOpen)
    {
        // If the settings or credits panel is open, don't open the other one
        if(flag && (isSettingsOpen || isCreditsOpen))
            return;
        if(flag)
        {
            uiManagerMenu.GoLeft();
            uiManager.FadeInPanel();
            uiManager.canvasGroup.interactable = true;
            uiManager.canvasGroup.blocksRaycasts = true;
            isPanelOpen = true;
        }
            
        else
        {
            uiManagerMenu.GoRight();
            uiManager.FadeOutPanel();
            uiManager.canvasGroup.interactable = false;
            uiManager.canvasGroup.blocksRaycasts = false;
            isPanelOpen = false;
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
        {
             image.sprite = onOffButtons[1];
             if(btn == musicOnOff)
                 AudioManager.Instance.MuteAudio(false);
             else if(btn == soundOnOff)
                AudioManager.Instance.MuteSounds(false);
        }
           
        else
        {
            image.sprite = onOffButtons[0];
            if(btn == musicOnOff)
                 AudioManager.Instance.MuteAudio(true);
             else if(btn == soundOnOff)
                AudioManager.Instance.MuteSounds(true);
        }
            

    }

}
