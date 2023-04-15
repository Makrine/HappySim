using UnityEngine;

/// <summary>
/// This class is used to adjust the sorting layer of the object based on the player's position
/// </summary>
public class AdjustSortingLayer : MonoBehaviour
{
    public string playerTag = "Player";

    private GameObject playerObject;
    private Renderer rendererComponent;

    private string sortingLayerName;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag(playerTag);
        rendererComponent = GetComponent<Renderer>();
        sortingLayerName = rendererComponent.sortingLayerName;
    }

    void Update()
    {
        if (playerObject.transform.position.y > transform.position.y)
        {
            rendererComponent.sortingLayerName = "InFrontOfPlayer";
        }
        else
        {
            rendererComponent.sortingLayerName = sortingLayerName;
        }
        
    }
}
