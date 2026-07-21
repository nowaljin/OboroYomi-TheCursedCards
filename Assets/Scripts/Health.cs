using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int totalHealth = 100;

    private int currentHealth;


    private void Start()
    {
        //currentHealth = totalHealth;
        currentHealth = 98;
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


}
