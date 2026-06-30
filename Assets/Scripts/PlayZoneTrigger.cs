using UnityEngine;

public class PlayZoneTrigger : MonoBehaviour
{
    [SerializeField] private PlayerHand playerHand;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent(out Card card))
        {
            Debug.Log("CARD entered");
            playerHand.PlayCard(card);

        }

    }

    private void OTriggerExit2D(Collider2D collision)
    {
         
        if (collision.TryGetComponent(out Card card))
        {
            Debug.Log("CARD left");

        }
    }


}
