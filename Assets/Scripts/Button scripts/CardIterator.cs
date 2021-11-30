using UnityEngine;
using UnityEngine.UI;

public class CardIterator : MonoBehaviour
{
    public void BringCardToFront()
    {
        if (this.transform.childCount > 0)
        {
            this.transform.GetChild(0).SetAsLastSibling();
        }
        else
        {
            this.transform.GetComponent<Image>().enabled = false; 
        }
    }
}