using UnityEngine;

public class FactoryProducer : MonoBehaviour
{
    [SerializeField]
    public KlondikeSpawner spawner;
        
    public AbstractFactory CreateGameFactory(SolitaireType solitaireType)
    {
        switch (solitaireType)
        {
            case SolitaireType.Klondike:
                return new KlondikeFactory(this.spawner as KlondikeSpawner);
            default:
                return null;
        }
    }
}
