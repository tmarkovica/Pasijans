using System;
using System.Collections.Generic;
using System.Linq;

public class DeckOfCards
{
    private List<Card> deckOfCards;

    public DeckOfCards()
    {
        string[] colors = new string[] { "club", "diamond", "hearth", "spade" };
        string[] names = new string[] { "ace" ,"two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king" };
        int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        this.deckOfCards = new List<Card>();

        for (int i = 0; i < 4; i++) // 4 colors
        {
            for (int j = 0; j < 13; j++) // 13 suits
            {
                this.deckOfCards.Add(new Card(colors[i], names[j], values[j]));
            }
        }
    }

    public void ShuffleCards()
    {
        Random random = new Random();

        int numberOfCards = deckOfCards.Count();

        List<Card> shuffledDeckOfCards = new List<Card>();

        int randomNumber;

        for (int i = numberOfCards; i > 0; i--)
        {
            randomNumber = random.Next(0, i);
            shuffledDeckOfCards.Add(deckOfCards[randomNumber]);
            deckOfCards.Remove(deckOfCards[randomNumber]);
        }

        deckOfCards.Clear();
        deckOfCards.AddRange(shuffledDeckOfCards);
    }

    public Card GetCard(int index)
    {
        if (index < 52)
            return deckOfCards.ElementAt(index);
        else
            return null;
    }

    public int Count
    {
        get { return this.deckOfCards.Count; }
        set { }
    }
}