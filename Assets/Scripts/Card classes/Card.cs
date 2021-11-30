using UnityEngine;

public class Card
{
    private string cardSuit;
    private string cardName;
    private int cardValue;

    public Card(string suit, string name, int value)
    {
        this.cardSuit = suit;
        this.cardName = name;
        this.cardValue = value;
    }

    public string GetCardSuit() { return cardSuit; }

    public string GetCardName() { return cardName; }

    public int GetCardValue() { return cardValue; }

    public string GetCardImageName()
    {
        return cardName + "_of_" + cardSuit + "s";
    }

    public Sprite GetSprite()
    {
        return Resources.Load<Sprite>("Textures/" + this.cardSuit + "s/" + GetCardImageName());
    }
}
