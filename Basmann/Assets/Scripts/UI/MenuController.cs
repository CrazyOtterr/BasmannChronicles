using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingsPanel;
    public GameObject mainMenu;        // Canvas_menu

    [Header("Sliders")]
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;


    private void Start()
    {
        // Убедимся, что при запуске видно только главное меню
        if (mainMenu != null)
            mainMenu.SetActive(true);
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void OpenSettingsPanel()
    {
        if (mainMenu != null)
            mainMenu.SetActive(false);
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
        if (mainMenu != null)
            mainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрыта");
        Application.Quit();
    }
    

    public void OnContinue()
    {
        Debug.Log("Продолжить игру (позже можно добавить загрузку сохранения)");
    }

    public void OnNewGame()
    {
        Debug.Log("Новая игра");
        SceneManager.LoadScene("GameScene"); // Название сцены игры
    }

    public void OnMap()
    {
        Debug.Log("Карта (позже можно добавить окно карты)");
    }

    public void OnHelp()
    {
        Debug.Log("Помощь");
    }

   

    // === События ползунков ===
    public void OnMasterVolumeChanged(float value)
    {
        Debug.Log($"Общая громкость: {value}");
        // Тут можно связать с AudioMixer
    }

    public void OnMusicVolumeChanged(float value)
    {
        Debug.Log($"Громкость музыки: {value}");
    }

    public void OnSFXVolumeChanged(float value)
    {
        Debug.Log($"Громкость звуков: {value}");
    }
}
