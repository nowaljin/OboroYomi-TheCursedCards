using UnityEngine;

public class PlayZoneTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent(out Card card))
        {
            Debug.Log("CARD entered");

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
