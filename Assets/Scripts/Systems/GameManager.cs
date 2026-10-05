using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float transitionTime;

    [SerializeField] private TextMeshProUGUI winLoseDisplay;

    private void Start()
    {
        Time.timeScale = 1f;
    }
   private void OnEnable()
    {
        BossEvents.OnBossDeath += PlayerWin;
        PlayerEvents.OnPlayerDeath += PlayerLose;

    }

    private void OnDisable()
    {
        BossEvents.OnBossDeath -= PlayerWin;
        PlayerEvents.OnPlayerDeath -= PlayerLose;

    }

    private void PlayerWin()
    {
        winLoseDisplay.text = "You defeated the boss!";
        StartCoroutine(RestartGame());
    }

    private void PlayerLose()
    {
        winLoseDisplay.text = "Game Over!";
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("GameScene"); //load game scene

        //load game over scene
    }



}
