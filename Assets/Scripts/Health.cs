using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int totalHealth = 100;

    private int currentHealth;


    private void Start()
    {
        currentHealth = totalHealth;
        
    }

    public void HealDamage(int amount)
    {
       Debug.Log("Healing Damage: " );

       if (amount <= 0)
       {
            
            return;
       }

       currentHealth += amount;
      
      
        if (currentHealth > totalHealth)
        {
            currentHealth = totalHealth;
        }
        Debug.Log(currentHealth);


    }

    public void TakeDamage(int amount)
    {
       currentHealth -= amount;
       Debug.Log("Health after damaged " + currentHealth);

    }


    public bool IsAlive()
    {
        return currentHealth > 0;
    }


}
