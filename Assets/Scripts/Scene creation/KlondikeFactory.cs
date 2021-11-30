using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KlondikeFactory : AbstractFactory
{
    private KlondikeSpawner spawner;

    private List<Image> lowerFoundations;
    private List<Image> upperFoundations;

    public KlondikeFactory(KlondikeSpawner spawner)
    {
        this.spawner = spawner;

        this.spawner.PrepSpawner();
    }

    public void CreateGame()
    {
        this.lowerFoundations = new List<Image>();
        this.upperFoundations = new List<Image>();    

        CreateUpperFoundations();
        CreateLowerFoundations();
        CreateDeck();
    }

    private void CreateLowerFoundations()
    {
        int xPosition = -1560;

        for (int i = 0; i < 7; i++)
        {
            Vector3 spawnPosition = new Vector3(xPosition, 320, 0);

            Image foundation = this.spawner.InstantiateFoundation(spawnPosition);

            foundation.GetComponent<DropReciever>().TypeOfStacking = TypeOfStacking.DSC;

            this.spawner.Instantiate_NumberOfCards_OnFoundation(i + 1, foundation);

            xPosition += 520;

            this.lowerFoundations.Add(foundation);
        }
    }

    private void CreateUpperFoundations()
    {
        float xPosition = 0;

        for (int i = 0; i < 4; i++)
        {
            Vector3 spawnPosition = new Vector3(xPosition, 900, 0);

            Image foundation = this.spawner.InstantiateFoundation(spawnPosition);

            foundation.GetComponent<DropReciever>().TypeOfStacking = TypeOfStacking.ASC;

            xPosition += 520;

            this.upperFoundations.Add(foundation);
        }
    }

    private void CreateDeck()
    {
        Vector3 spawnPosition = new Vector3(-1560, 900, 0);

        this.spawner.InstantiateDeck(spawnPosition);
    }
    
    public void GameCompletedTest(GameEndTester gameEndTest)
    {
        gameEndTest.TestFoundations(this.lowerFoundations);
        gameEndTest.TestFoundations(this.upperFoundations);
    }
}