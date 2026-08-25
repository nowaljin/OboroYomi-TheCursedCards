using System;
using UnityEngine;

public static class PlayerEvents
{
   public static event Action<CardData> OncardPlayed;

   public static void CardPlayed(CardData cardData)
    {
        
        OncardPlayed?.Invoke(cardData);

    }

    

}
