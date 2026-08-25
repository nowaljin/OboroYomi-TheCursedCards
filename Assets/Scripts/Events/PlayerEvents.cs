using System;
using UnityEngine;

public static class PlayerEvents
{
   public static event Action<CardData> OncardPlayed;

   public static event Action<int> OnPlayerHit;

   public static void CardPlayed(CardData cardData)
    {
        
        OncardPlayed?.Invoke(cardData);

    }

    public static void PlayerHit(int damage)
    {
        OnPlayerHit?.Invoke(damage);
    }

    

}
