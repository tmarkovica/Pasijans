using UnityEngine;

namespace Assets.Scripts
{
    public class Klondike
    {
        public static string GetCardColor(string suit) // "club", "spade" == "black"; "diamond", "hearth" == "red"
        {
            if (suit == "club" || suit == "spade")
                return "black";
            else
                return "red";
        }

        public static bool CanDrop(Card droppingCard, Card catchingCard, TypeOfStacking typeOfStacking)
        {
            Debug.Log("child: " + droppingCard.GetCardImageName() + " parent: " + catchingCard.GetCardImageName() + ", type: " + typeOfStacking);

            if (typeOfStacking == TypeOfStacking.DSC)
            {
                if (GetCardColor(droppingCard.GetCardSuit()) != GetCardColor(catchingCard.GetCardSuit()))
                {
                    if (droppingCard.GetCardValue() == catchingCard.GetCardValue() - 1)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else if (typeOfStacking == TypeOfStacking.ASC)
            {
                if (droppingCard.GetCardSuit() == catchingCard.GetCardSuit())
                {
                    if (droppingCard.GetCardValue() - 1 == catchingCard.GetCardValue())
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static bool CanDrop(Card droppingCard, TypeOfStacking typeOfStacking)
        {
            int n;

            switch (droppingCard.GetCardValue())
            {
                case 1:
                    n = 1;
                    break;
                case 13:
                    n = 13;
                    break;
                default:
                    n = 0;
                    break;
            }

            Debug.Log("n = " + n + "; typeOfStacking = " + typeOfStacking);


            if (typeOfStacking == TypeOfStacking.ASC && n == 1)
                return true;
            else if (typeOfStacking == TypeOfStacking.DSC && n == 13)
                return true;
            else
                return false;
        }
    }
}
