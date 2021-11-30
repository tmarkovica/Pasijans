public class CardDealer
{
    private DeckOfCards deck;
    private int cardCounter;

    public CardDealer()
    {
        this.deck = new DeckOfCards();
    }

    public void Shuffle()
    {
        deck.ShuffleCards();
        cardCounter = 0;
    }

    public Card PullCard()
    {
        Card tempCard = deck.GetCard(cardCounter);

        if (IsOutOfCards() == false)
            cardCounter++;

        return tempCard;
    }

    public bool IsOutOfCards()
    {
        //if (cardCounter >= 52) return true;
        if (cardCounter >= this.deck.Count) return true;
        else return false;
    }
}