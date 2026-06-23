using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer illustrationRender;

    [SerializeField] private TextMeshPro cardNameText;

    [SerializeField] private TextMeshPro descriptionText;

    [SerializeField] private TextMeshPro actionsText;

    private Vector3 orginalScale;

    private Vector3 orginalPosition;

    [SerializeField] private float hoverScale = 2f;
    [SerializeField] private float hoverOffset = 2f;

    private SortingGroup sortingGroup;

    private int originalSortingOrder;

   


    private void Awake()
    {
        sortingGroup = GetComponent<SortingGroup>();
        
    }


    private void Start()
    {
        orginalScale = transform.localScale;
        orginalPosition= transform.localPosition;
        originalSortingOrder = sortingGroup.sortingOrder;
       
    }

    public void LoadCardData(CardData cardData)
    {
        illustrationRender.sprite= cardData.illustration;
        cardNameText.text = cardData.cardName;
        descriptionText.text = cardData.description;
        actionsText.text = cardData.actionCost.ToString();

    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse Entered");
        transform.localScale = orginalScale * hoverScale;
        transform.localPosition += new Vector3(0, hoverOffset, 0f);
        sortingGroup.sortingOrder += 1;
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        transform.localScale = orginalScale;
        transform.localPosition = orginalPosition;
        sortingGroup.sortingOrder = originalSortingOrder;
    }
}
