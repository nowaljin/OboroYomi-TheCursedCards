using UnityEngine;
using System;

public static class BossEvents
{
    public static event Action<CardData> OnBossHit;

   public static void BossHit(CardData cardData)
    {
        
        OnBossHit?.Invoke(cardData);

    }
}
