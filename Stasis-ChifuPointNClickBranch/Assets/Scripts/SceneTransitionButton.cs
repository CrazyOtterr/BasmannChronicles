using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionButton : MonoBehaviour
{
    [Header("Scene Transition Settings")]
    [Tooltip("The name of the scene to transition to")]
    public string targetSceneName = "Game";
    
    [Tooltip("Reference to the button component")]
    private Button transitionButton;
    
    void Start()
    {
        // Get the button component
        transitionButton = GetComponent<Button>();
        
        // Add listener for button click
        if (transitionButton != null)
        {
            transitionButton.onClick.AddListener(TransitionToScene);
        }
        else
        {
            Debug.LogError("No Button component found on this GameObject!");
        }
    }
    
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
    
    void OnDestroy()
    {
        // Remove listener when object is destroyed
        if (transitionButton != null)
        {
            transitionButton.onClick.RemoveListener(TransitionToScene);
        }
    }
}