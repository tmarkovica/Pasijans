using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonClick()
    {
        SceneManager.LoadScene("Solitaire");
        Debug.Log("PlayButtonClick()");
    }

    public void OptionsButtonClick()
    {

    }

    public void ExitButtonClick()
    {
        Debug.Log("ExitButtonClick()");
        Application.Quit();
    }
}
