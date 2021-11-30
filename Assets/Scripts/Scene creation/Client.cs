using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField]
    private FactoryProducer producer;

    [SerializeField]
    private GameObject popUpWindow;

    public GameEndTester tester;

    private AbstractFactory factory;

    void Start()
    {        
        this.tester = new GameEndTester(this.popUpWindow);

        this.factory = this.producer.CreateGameFactory(SolitaireType.Klondike);
        this.factory.CreateGame();        
    }

    void Update()
    {
        this.factory.GameCompletedTest(this.tester);
    }
}
