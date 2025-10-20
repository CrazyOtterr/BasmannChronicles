using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetupHelper : MonoBehaviour
{
    [Header("Scene Setup")]
    [Tooltip("Ensure GameManager exists in this scene")]
    public bool ensureGameManager = true;
    
    [Tooltip("Ensure player exists in this scene")]
    public bool ensurePlayer = true;
    
    void Awake()
    {
        // Ensure GameManager exists
        if (ensureGameManager && GameManager.instance == null)
        {
            GameObject gameManagerPrefab = new GameObject("GameManager");
            gameManagerPrefab.AddComponent<GameManager>();
        }
        
        // Ensure UIManager exists
        if (UIManager.instance == null)
        {
            GameObject uiManagerPrefab = new GameObject("UIManager");
            uiManagerPrefab.AddComponent<UIManager>();
        }
    }
    
    void Start()
    {
        Debug.Log("Scene '" + SceneManager.GetActiveScene().name + "' is ready.");
    }
}