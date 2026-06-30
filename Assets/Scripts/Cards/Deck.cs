using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<CardData> drawPile = new List<CardData>();
    [SerializeField] private GameObject cardBack;

    [SerializeField] private PlayerHand playerHand;

    // Track the visual card objects so we can remove them when drawing
    private List<GameObject> cardVisuals = new List<GameObject>();

    private const float VERTICAL_SPACING = .1f;

    private void Start()
    {
        Shuffle();
        DeckDrawVisuals();
    }

    public CardData DrawCard()
    {
        if (drawPile.Count > 0)
        {
            // 1. Handle Logical Data
            int topIndex = drawPile.Count - 1;
            CardData data = drawPile[topIndex];
            drawPile.RemoveAt(topIndex);

            // 2. Handle Visuals
            if (cardVisuals.Count > 0)
            {
                int visualTopIndex = cardVisuals.Count - 1;
                Destroy(cardVisuals[visualTopIndex]);
                cardVisuals.RemoveAt(visualTopIndex);
            }

            return data;
        }

        Debug.LogWarning("Tried to draw, but the deck is empty!");
        return null;
    }

    private void DeckDrawVisuals()
    {
        
        for (int i = 0; i < drawPile.Count; i++)
        {
            
            GameObject newCardBack = Instantiate(cardBack, transform);
            newCardBack.transform.localPosition = new Vector3(0f, -i * VERTICAL_SPACING, 0f);
            
        }
    }

     public void Shuffle()
    {
        for (int i = 0; i < drawPile.Count; i++)
        {
            CardData card = drawPile[i];
            int randomIndex = Random.Range(i, drawPile.Count);
            drawPile[i] = drawPile[randomIndex];
            drawPile[randomIndex] = card;
        }
    }

    private void OnMouseDown()
    {
        if(drawPile.Count <=0)
        {
            return;
        }
        playerHand.DrawNextCard();
    }

}