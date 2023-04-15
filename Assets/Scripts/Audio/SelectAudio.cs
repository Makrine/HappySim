using UnityEngine;

public class SelectAudio : MonoBehaviour
{
    public Audio clip;

    public void PlayAudio()
    {
        AudioManager.Instance.PlayAudio(this);
    }
}

[System.Serializable]
public enum Audio
{
    ButtonClick,
    Popup
}