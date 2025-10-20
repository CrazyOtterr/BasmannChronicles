using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Singleton instance
    public static UIManager instance;
    
    [Header("UI References")]
    [Tooltip("Reference to the transition button")]
    public Button transitionButton;
    
    [Tooltip("The name of the scene to transition to")]
    public string targetSceneName = "Game";
    
    void Awake()
    {
        // Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        // Setup button listener
        if (transitionButton != null)
        {
            transitionButton.onClick.AddListener(OnTransitionButtonClicked);
        }
    }
    
    /// <summary>
    /// Called when the transition button is clicked
    /// </summary>
    public void OnTransitionButtonClicked()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogError("GameManager not found!");
        }
    }
}