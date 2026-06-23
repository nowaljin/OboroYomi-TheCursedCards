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

    [SerializeField] private CardData tempCardData;


    
    void Start()
    {
        orginalScale = transform.localScale;
        orginalPosition= transform.localPosition;

        LoadCardData(tempCardData);
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
        transform.localScale = orginalScale * 2;
        transform.localPosition += new Vector3(0, 2f, 0f);
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        transform.localScale = orginalScale;
        transform.localPosition = orginalPosition;
    }
}
