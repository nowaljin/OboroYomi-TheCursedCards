using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class DiscardPile : MonoBehaviour
{
   [SerializeField] private List<CardData> discardPile = new List<CardData>();

   [SerializeField] private GameObject cardPrefab;

   private const float VERTICAL_SPACING = .25f;

   public void DiscardCard (CardData cardData)
    {
         Debug.Log("Discard card + " +  cardData);
         discardPile.Add(cardData);

         GameObject discardedCard = Instantiate(cardPrefab, transform);

         discardedCard.GetComponent<Card>().LoadCardData(cardData);

         discardedCard.GetComponent<Card>().SetInteractable(false);
         

         SortingGroup sortingGroup = discardedCard.GetComponent<SortingGroup>();
         sortingGroup.sortingOrder = discardPile.Count - 1;

         discardedCard.transform.SetParent(transform);

         discardedCard.transform.localPosition = new Vector3(0f, (discardPile.Count -1) * -VERTICAL_SPACING, 0f);


    }

}
