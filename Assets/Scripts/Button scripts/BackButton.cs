using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class BackButton : MonoBehaviour
{
    [SerializeField]
    private GameObject popUpWindow;

    public void ShowPopUp_ExitToMainMenu()
    {
        this.popUpWindow.GetComponent<PopUpWindowManager>().PopUp_ExitToMainMenu();
    }
}
