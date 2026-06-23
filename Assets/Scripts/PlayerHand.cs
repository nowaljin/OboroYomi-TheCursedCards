using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Deck deck;

    [SerializeField] private Transform[] cardSlots;

    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private int startingHandSize = 2;

    private List<Card> cardsInHand = new List<Card>();
    void Start()
    {
        for (int i = 0; i < startingHandSize; i++)
        {
            DrawNextCard();
        }
    }

    public void DrawNextCard()
    {
        CardData cardData = deck.DrawCard();
        int slotIndex = cardsInHand.Count;
        GameObject newCard = Instantiate(cardPrefab, cardSlots[slotIndex].position, Quaternion.identity);
        Card cardComponent = newCard.GetComponent<Card>();
        cardsInHand.Add(cardComponent);
        cardsInHand[slotIndex].transform.SetParent(cardSlots[slotIndex]);


    }


}
