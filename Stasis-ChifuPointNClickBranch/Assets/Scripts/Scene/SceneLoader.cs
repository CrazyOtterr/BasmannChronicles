using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sc;

    public void LoadScene()
    {
        SceneManager.LoadScene(sc);
    }
}
