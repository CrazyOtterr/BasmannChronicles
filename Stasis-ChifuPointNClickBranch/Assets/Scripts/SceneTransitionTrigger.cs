using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    [Header("Scene Transition Settings")]
    [Tooltip("The name of the scene to transition to")]
    public string targetSceneName = "Game";
    
    [Tooltip("Whether to transition when player enters the trigger")]
    public bool transitionOnEnter = true;
    
    [Tooltip("Whether to show a button for manual transition")]
    public bool showTransitionButton = false;
    
    private bool playerInTrigger = false;
    
    // Detect when the player enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering is the player (by tag, name, or layer)
        if (IsPlayer(other.gameObject))
        {
            playerInTrigger = true;
            
            // If set to transition automatically on enter
            if (transitionOnEnter)
            {
                TransitionToScene();
            }
        }
    }
    
    // Detect when the player exits the trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object exiting is the player (by tag, name, or layer)
        if (IsPlayer(other.gameObject))
        {
            playerInTrigger = false;
        }
    }
    
    // Helper method to check if an object is the player
    private bool IsPlayer(GameObject obj)
    {
        return obj.CompareTag("Player") || 
               obj.name == "Player" || 
               obj.layer == LayerMask.NameToLayer("IsPlayer");
    }
    
    // Manual transition method (can be called by a button)
    public void TransitionToScene()
    {
        // Check if the scene name is valid
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            Debug.Log("Transitioning to scene: " + targetSceneName);
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogError("Target scene name is not set!");
        }
    }
    
    // This method can be called by a UI button
    public void OnTransitionButtonPressed()
    {
        if (playerInTrigger)
        {
            TransitionToScene();
        }
    }
}