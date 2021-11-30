using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndTester
{
    private GameObject popUpWindow;

    public GameEndTester(GameObject popUpWindow)
    {
        this.popUpWindow = popUpWindow;
    }

    public void TestFoundations(List<Image> foundations)
    {
        int testsPassed = 0;

        foreach (Image foundation in foundations)
        {
            if (TestStack(foundation.transform))
                testsPassed++;
        }

        if (testsPassed == 4)
        {
            //Debug.LogError("Game is finished...");
            this.popUpWindow.GetComponent<PopUpWindowManager>().PopUp_GameFinished();
        }            
    }

    private int GetCardValue(Transform card)
    {
        return card.GetComponent<CardHolder>().Card.GetCardValue();
    }

    private bool TestStack(Transform foundation)
    {
        if (foundation.childCount == 0)
            return false;

        Transform firstChild = foundation.transform.GetChild(0);

        int n = 0;

        if (CheckCardInStack(firstChild, n))
            return true;
        else
            return false;
    }

    private bool CheckCardInStack(Transform card, int n)
    {
        if (card.childCount != 0)
        {
            return CheckCardInStack(card.transform.GetChild(0), n + GetCardValue(card)); // gives current card value
        }
        else
        {
            if (n + GetCardValue(card) == 91)
                return true;
            else
                return false;
        }
    }
}
