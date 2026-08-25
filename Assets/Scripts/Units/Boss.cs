using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
   
   private Health health;

   private Animator animationController;

   private Vector3 originalPosition;

   [SerializeField] private GameObject bossSprite;

    private void Awake()
    {
        health = GetComponent<Health>();
        animationController = bossSprite.GetComponent<Animator>();
    }

    private void Start()
    {
        originalPosition = bossSprite.transform.position;
    }

   private void OnEnable()
    {
        BossEvents.OnBossHit += HandleBossHit;
        TurnEvents.OnBossTurnStart += Attack;
    }

    private void OnDisable()
    {
        BossEvents.OnBossHit -= HandleBossHit;
        TurnEvents.OnBossTurnStart -= Attack;
    }

    private void Attack()
    {
        Debug.Log("Boss is attacking!");
        StartCoroutine(BossAttackAnimation());
        
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

    private IEnumerator BossAttackAnimation()
    {
        Vector3 targetPosition = originalPosition + new Vector3(-4f, 0, 0);

        float duration = .5f;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            
            bossSprite.transform.position = Vector3.Lerp(originalPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
           
        }

        animationController.Play("Attack");
        


        yield return new WaitForSeconds(0.5f);



        timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            
            bossSprite.transform.position = Vector3.Lerp(targetPosition, originalPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
           
        }



        
    
        yield return null;
    }


}
