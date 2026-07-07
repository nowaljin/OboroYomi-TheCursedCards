using UnityEngine;

public class Player : MonoBehaviour
{
    
  
    private void OnEnable()
    {
        PlayerEvents.OncardPlayed += HandleCardPlayed;

    }

    private void OnDisable()
    {
        PlayerEvents.OncardPlayed -= HandleCardPlayed;
    }

    private void HandleCardPlayed(CardData cardData)
    {
        
        Debug.Log("handler ran");
    }
    
        
    

  
}
