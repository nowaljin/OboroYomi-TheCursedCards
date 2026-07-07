using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
   public static event Action<CardData> OncardPlayed;

   public static void CardPlayed(CardData cardData)
    {
        
        OncardPlayed?.Invoke(cardData);

    }

    

}
