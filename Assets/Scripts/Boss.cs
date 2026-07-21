using UnityEngine;

public class Boss : MonoBehaviour
{
   
   private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

   private void OnEnable()
    {
        BossEvents.OnBossHit += HandleBossHit;
    }

    private void OnDisable()
    {
        BossEvents.OnBossHit -= HandleBossHit;
    }

    private void HandleBossHit(CardData cardData)
    {
        Debug.Log("Boss was hit! ");
        health.TakeDamage(cardData.attackPower);
      
    }


}
