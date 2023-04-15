using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            // if this is "shop" scene, load "game" scene else load shop scene
            if (SceneManager.GetActiveScene().name == "Shop")
                SceneManager.LoadScene("Game");
            else
                SceneManager.LoadScene("Shop");
        }
    }
}
