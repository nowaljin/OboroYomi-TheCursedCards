using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject playerSprite;

    private Vector3 originalPosition;

    private Animator animationController;

    private ParticleSystem healVFX;

    private Health health;
    
  
    private void OnEnable()
    {
        PlayerEvents.OncardPlayed += HandleCardPlayed;

    }

    private void OnDisable()
    {
        PlayerEvents.OncardPlayed -= HandleCardPlayed;
    }

    private void Awake()
    {
        animationController = playerSprite.GetComponent<Animator>();
        health = GetComponent<Health>();
        healVFX = playerSprite.GetComponentInChildren<ParticleSystem>();


    }

    private void Start()
    {
        originalPosition = playerSprite.transform.position;
    }

    private void HandleCardPlayed(CardData cardData)
    {
        
        Debug.Log("handler ran");

        if(cardData.attackPower > 0)
        {
            //attack
            Attack(cardData);
        }

        if (cardData.healPower > 0)
        {
            //heal
            Heal(cardData);
        }

    }
    
    private void Attack(CardData cardData)
    {
        Debug.Log("attack!" + cardData.attackPower);
        StartCoroutine(PlayerAttackAnimation());

    }

    private void Heal(CardData cardData)
    {
        Debug.Log("heal! " + cardData.healPower);
        health.HealDamage(cardData.healPower);
        healVFX.Play();
    }

    private IEnumerator PlayerAttackAnimation()
    {
        Vector3 targetPosition = originalPosition + new Vector3(4f, 0, 0);

        float duration = .5f;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            
            playerSprite.transform.position = Vector3.Lerp(originalPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
           
        }

        animationController.Play("Attack");

        yield return new WaitForSeconds(0.5f);



        timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            
            playerSprite.transform.position = Vector3.Lerp(targetPosition, originalPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
           
        }



        
    
        yield return null;
    }

        
    

  
}
