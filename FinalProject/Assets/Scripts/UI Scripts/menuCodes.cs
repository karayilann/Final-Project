using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuCodes : MonoBehaviour
{
    public GameObject levelPaneli;
    public GameObject settings;
    public GameObject credits;

    //public int levelIndex;

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
    }

    /*
    /// <summary>
    /// Farklý leveller eklendikten sonra burasý aktif edilecek.
    /// </summary>
    public void level1()
    {
        SceneManager.LoadScene(levelIndex);
    }
    */

}
