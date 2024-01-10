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
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI coinScore;
    public TextMeshProUGUI highScoreSea;
    public TextMeshProUGUI coinScoreSea;
    public TextMeshProUGUI highScoreM�s�r;
    public TextMeshProUGUI coinScoreM�s�r;

    private void Start()
    {
        mainMenu.SetActive(true);
        levelPaneli.SetActive(false);

        text = FindAnyObjectByType<TextMover>();
        string scoreNumber = Score.oyuncuSkoru;
        highScore.text = scoreNumber;
        int coinNumber = Score.coinStash;
        coinScore.text = coinNumber.ToString();

        string scoreNumberSea = Score.oyuncuSkoruSea;
        highScoreSea.text = scoreNumberSea;
        int coinNumberSea = Score.coinStashSea;
        coinScoreSea.text = coinNumberSea.ToString();

        string scoreNumberM�s�r = Score.oyuncuSkoruM�s�r;
        highScoreM�s�r.text = scoreNumberM�s�r;
        int coinNumberM�s�r = Score.coinStashM�s�r;
        coinScoreM�s�r.text = coinNumberM�s�r.ToString();
    }

    public void PlayButton()
    {
        settings.SetActive(false);
        credits.SetActive(false);
        levelPaneli.SetActive(true);
        mainMenu.SetActive(false);
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

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }


}
