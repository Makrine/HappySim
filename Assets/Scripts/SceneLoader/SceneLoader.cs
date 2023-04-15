using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    /// <summary>
    /// get the curernt scene
    /// </summary>
    public Scene CurrentScene()
    {
        return (Scene)SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(Scene scene)
    {
        // load scene with its index
        SceneManager.LoadScene((int)scene);
    }

    public void Menu()
    {
        LoadScene(Scene.Menu);
    }
}

[System.Serializable]
public enum Scene
{
    Menu,
    Game
}
