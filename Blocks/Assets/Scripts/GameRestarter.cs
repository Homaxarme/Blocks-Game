using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerSpawner))]
public class GameRestarter : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private int pointsRequired = 5;
    /// <summary>
    /// Sets the position of a player back to their spawn point
    /// </summary>
    /// <param name="playerNumber"></param> This is the player which will be affected
    private void ResetPositionOfPlayers(int playerNumber)
    {
            GetComponent<PlayerSpawner>().players[playerNumber].transform.SetPositionAndRotation(GetComponent<PlayerSpawner>().spawnPositions[playerNumber], Quaternion.identity);
    }
    public IEnumerator UpdateGameState()
    {
        yield return new WaitForSeconds(2);
        if(GetComponent<ScoreBoard>().playerOneScore == pointsRequired || GetComponent<ScoreBoard>().playerTwoScore == pointsRequired)
        {
            EndGame();
        }
        else
            ResetGame();
    }

    private void EndGame()
    {
        endScreen.SetActive(true);
        if (GetComponent<ScoreBoard>().playerOneScore == pointsRequired)
        {
            endScreen.transform.Find("Player# Wins").GetComponent<Text>().text = "Player One Wins";
            endScreen.transform.Find("Player# Wins").GetComponent<Text>().color = Color.red;
        }
        else
        {
            endScreen.transform.Find("Player# Wins").GetComponent<Text>().text = "Player Two Wins";
            endScreen.transform.Find("Player# Wins").GetComponent<Text>().color = Color.blue;
        }
    }

    private void ResetGame()
    {
        for (int i = 0; i < GetComponent<PlayerSpawner>().players.Count; i++)
        {
            ResetPositionOfPlayers(i);
            RevivePlayes(i);
        }
        GetComponent<ScoreBoard>().isGameEnded = false;
    }

    private void RevivePlayes(int i)
    {
        GetComponent<PlayerSpawner>().players[i].GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerSpawner>().players[i].isDead = false;
    }
}
