using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip buttonClick;
    public AudioClip popup;
    public AudioClip popupClose;
    public AudioClip coins;
    public static AudioManager Instance;
    public AudioSource audioSourceBackground;
    public AudioSource audioSourceEffects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Play an audio clip
    /// </summary>
    public void PlayAudio(SelectAudio selectAudio)
    {
        switch (selectAudio.clip)
        {
            case Audio.ButtonClick:
                audioSourceEffects.PlayOneShot(buttonClick);
                break;
            case Audio.Popup:
                audioSourceEffects.PlayOneShot(popup);
                break;
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        audioSourceEffects.PlayOneShot(clip);
    }

    /// <summary>
    /// Mute or unmute all audio sources
    /// </summary>
    public void MuteAudio(bool flag)
    {
        audioSourceBackground.mute = flag;
    }

    public void MuteSounds(bool flag)
    {
        audioSourceEffects.mute = flag;
    }

}
