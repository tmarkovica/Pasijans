using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Droppable
{
    abstract public void Drop(Transform child, Transform parent, TypeOfStacking type);

    public Card GetCardFromHolder(Transform transform)
    {
        if (transform.GetComponent<CardHolder>() != null)
            return transform.GetComponent<CardHolder>().Card;
        else
            return null;
    }
}
