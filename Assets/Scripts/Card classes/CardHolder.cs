using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour
{
    private Card card;

    private Sprite spriteFront;
    private Sprite spriteBack;

    public Sprite Sprite
    {
        get 
        {
            return this.Sprite;
        }
        private set
        {
            this.GetComponent<Image>().sprite = value;
        }
    }

    private void SetCardEnabled(bool state) { this.GetComponent<Image>().raycastTarget = state; }

    public Card Card
    {
        get
        {
            return this.card;
        }
        set
        {
            this.card = value;
            this.spriteFront = card.GetSprite();
            this.spriteBack = Resources.Load<Sprite>("Textures/BackColor_Red");

            this.Sprite = spriteBack;
            SetCardEnabled(false);
        }
    }

    private bool faceUp = false;

    public void FlipCard()
    {
        if (faceUp == false)
        {
            this.Sprite = spriteFront;
            SetCardEnabled(true);
            faceUp = true;
        }
    }
}