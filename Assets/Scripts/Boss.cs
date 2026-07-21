using UnityEngine;

public class Boss : MonoBehaviour
{
   
   private Health health;

   private Animator animationController;

   [SerializeField] private GameObject bossSprite;

    private void Awake()
    {
        health = GetComponent<Health>();
        animationController = bossSprite.GetComponent<Animator>();
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
        if (!health.IsAlive())
        {
           
            //die
            Die();
        }
      
    }

    private void Die()
    {
       //trigger death anim
       animationController.Play("Die");
    }


}
