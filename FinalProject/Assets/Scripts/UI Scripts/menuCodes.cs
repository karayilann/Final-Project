using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuCodes : MonoBehaviour
{
    public GameObject levelPaneli;
    public GameObject settings;
    public GameObject credits;
    public GameObject mainMenu;

    TextMover text;
    public TextMeshProUGUI textMeshProUGUI;

    //public int levelIndex;

    private void Start()
    {
        text = FindAnyObjectByType<TextMover>();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        //settings.SetActive(false);
        //credits.SetActive(false);
        //levelPaneli.SetActive(true);
    }

    public void SettingsButton()
    {
        levelPaneli.SetActive(false);
        credits.SetActive(false);
        settings.SetActive(true);
    }

    public void CreditsButton()
    {
        levelPaneli.SetActive(false);
        credits.SetActive(true);
        settings.SetActive(false);
        textMeshProUGUI.rectTransform.anchoredPosition = new Vector2(0, -580.7f);
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        levelPaneli.SetActive(false);
        credits.SetActive(false);
        settings.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    /*
    /// <summary>
    /// Farkl� leveller eklendikten sonra buras� aktif edilecek.
    /// </summary>
    public void level1()
    {
        SceneManager.LoadScene(levelIndex);
    }
    */

}
