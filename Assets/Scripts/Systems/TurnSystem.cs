using System.Collections;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    [SerializeField] private float turnWaitTime = 3f;
    
    private void OnEnable()
    {
        PlayerEvents.OncardPlayed += CardPlayed;

    }

    private void OnDisable()
    {
        PlayerEvents.OncardPlayed -= CardPlayed;
    }

    private void CardPlayed(CardData cardData)
    {
        TurnEvents.PlayerTurnEnd();
        Debug.Log("Player Turn Ended");
        StartCoroutine(BossTurn());
    }

    private IEnumerator BossTurn()
    {
        yield return new WaitForSeconds(turnWaitTime);
        Debug.Log("Boss Turn Started");
        TurnEvents.BossTurnStart();
    }

}
