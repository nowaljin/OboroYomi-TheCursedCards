using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<CardData> drawPile = new List<CardData>();
    [SerializeField] private GameObject cardBackPrefab;

    // Track the visual card objects so we can remove them when drawing
    private List<GameObject> cardVisuals = new List<GameObject>();

    private const float VERTICAL_SPACING = 0.1f;

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
        // Clear existing visuals just in case this is called mid-game
        foreach (var visual in cardVisuals) Destroy(visual);
        cardVisuals.Clear();

        for (int i = 0; i < drawPile.Count; i++)
        {
            GameObject newCardBack = Instantiate(cardBackPrefab, transform);
            newCardBack.transform.localPosition = new Vector3(0f, -i * VERTICAL_SPACING, 0f);
            
            cardVisuals.Add(newCardBack);
        }
    }

    public void Shuffle()
    {
        // Fisher-Yates Shuffle Algorithm
        for (int i = drawPile.Count - 1; i > 0; i--)
        {
            // Explicitly use UnityEngine.Random to avoid System.Random conflict
            int randomIndex = UnityEngine.Random.Range(0, i + 1);
            
            CardData temp = drawPile[i];
            drawPile[i] = drawPile[randomIndex];
            drawPile[randomIndex] = temp;
        }
    }
}