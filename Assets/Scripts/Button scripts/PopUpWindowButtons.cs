using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpWindowButtons : MonoBehaviour
{
    public void NoButtonClick()
    {
        this.GetComponentInParent<PopUpWindowManager>().PopUpWindowEnabled(false);
    }

    public void YesButtonClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
