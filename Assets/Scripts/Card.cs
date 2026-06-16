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

    [SerializeField] private CardData tempCardData;


    
    void Start()
    {
        LoadCardData(tempCardData);
    }

    public void LoadCardData(CardData cardData)
    {
        illustrationRender.sprite= cardData.illustration;
        cardNameText.text = cardData.cardName;
        descriptionText.text = cardData.description;
        actionsText.text = cardData.actionCost.ToString();

    }

  
}
