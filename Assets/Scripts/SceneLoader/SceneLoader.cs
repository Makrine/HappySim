using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(Scene scene)
    {
        // load scene with its index
        SceneManager.LoadScene((int)scene);
    }
}

[System.Serializable]
public enum Scene
{
    Menu,
    Game
}
