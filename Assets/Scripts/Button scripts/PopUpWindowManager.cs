using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpWindowManager : MonoBehaviour
{
    [SerializeField]
    private GameObject title;

    [SerializeField]
    private GameObject message;


    public void PopUpWindowEnabled(bool state)
    {
        if (state)
        {
            this.gameObject.SetActive(true);
            this.transform.SetAsLastSibling();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private void SetTextToObject(GameObject obj, string text)
    {
        obj.GetComponent<Text>().text = text;
    }

    public void PopUp_ExitToMainMenu()
    {
        SetTextToObject(this.title, "ExitToMainMenu");
        PopUpWindowEnabled(true);
    }

    public void PopUp_GameFinished()
    {
        SetTextToObject(this.title, "YouFinishedTheGame");
        PopUpWindowEnabled(true);
    }
}
