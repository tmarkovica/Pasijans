using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class KlondikeSpawner : MonoBehaviour
{
    [SerializeField]
    private Image prefabCard;

    [SerializeField]
    private Image prefabFoundation;

    [SerializeField]
    private Image prefabDeck;

    [SerializeField]
    private Canvas canvas;

    private CardDealer dealer;

    private DropOnFoundation dropOnFoundation;
    private Droppable dropOnTop;
    private Droppable dropShifted;

    public void PrepSpawner()
    {
        this.dealer = new CardDealer();
        this.dealer.Shuffle();

        this.dropOnFoundation = new DropOnFoundation();
        this.dropOnTop = new DropOnTop();
        this.dropShifted = new DropShifted();

        this.dropOnFoundation.dropOnTop = dropOnTop;
        this.dropOnFoundation.dropShifted = dropShifted;
    }

    private void SetCardToImage(Card card, Image imageCard)
    {
        if (card != null)
        {
            imageCard.GetComponent<CardHolder>().Card = card;
        }
    }

    private void SetImageName(Image image, string name)
    {
        image.name = name;
    }

    private void SetTypeOfStackingByParentsType(Image image)
    {
        if (image.transform.parent.GetComponent<DropReciever>().TypeOfStacking == TypeOfStacking.ASC)
        {
            image.GetComponent<DropReciever>().TypeOfStacking = TypeOfStacking.ASC;
            image.GetComponent<DropReciever>().SetDropType(this.dropOnTop);
        }

        else if (image.transform.parent.GetComponent<DropReciever>().TypeOfStacking == TypeOfStacking.DSC)
        {
            image.GetComponent<DropReciever>().TypeOfStacking = TypeOfStacking.DSC;
            image.GetComponent<DropReciever>().SetDropType(this.dropShifted);
        }
    }

    private Image InstantiatePrefab(Image prefab)
    {
        return Instantiate(prefab, canvas.transform) as Image;
    }

    public Image InstantiateFoundation(Vector3 spawnPosition)
    {
        Image img = InstantiatePrefab(this.prefabFoundation);

        img.transform.localPosition = spawnPosition;

        SetImageName(img, img.transform.localPosition.ToString());

        img.GetComponent<DropReciever>().SetDropType(this.dropOnFoundation);

        return img;
    }

    private Image InstantianteCard(Vector3 spawnPosition, Image parentHolder)
    {
        Image imageCard = InstantiatePrefab(this.prefabCard);
        imageCard.GetComponent<DragDrop>().canvas = this.canvas;

        SetCardToImage(this.dealer.PullCard(), imageCard);
        SetImageName(imageCard, imageCard.GetComponent<CardHolder>().Card.GetCardImageName());

        imageCard.transform.SetParent(parentHolder.transform);
        imageCard.transform.localPosition = spawnPosition;

        return imageCard;
    }

    public void Instantiate_NumberOfCards_OnFoundation(int numberOfCards, Image foundation)
    {
        float yPosition = 0;
        Image parentCard = null;

        for (int i = 0; i < numberOfCards; i++)
        {
            Vector3 spawnPosition = new Vector3(0, yPosition, 0);

            if (i == 0)
            {
                parentCard = InstantianteCard(spawnPosition, foundation);
                yPosition = -100;
            }
            else
            {
                parentCard = InstantianteCard(spawnPosition, parentCard);
            }

            SetTypeOfStackingByParentsType(parentCard);
        }

        parentCard.GetComponent<CardHolder>().FlipCard();
    }

    public void InstantiateDeck(Vector3 spawnPosition)
    {
        Image deckImage = InstantiatePrefab(this.prefabDeck);
        deckImage.transform.localPosition = spawnPosition;

        deckImage.transform.SetAsLastSibling();

        do
        {
            Image imageCard = InstantianteCard(new Vector3(520, 0, 0), deckImage);
            imageCard.GetComponent<CardHolder>().FlipCard();

            imageCard.GetComponent<DropReciever>().TypeOfStacking = TypeOfStacking.NONE;
        } while (this.dealer.IsOutOfCards() == false);
    }
}