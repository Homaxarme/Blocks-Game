using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerSpawner))]
public class GameRestarter : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
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
        if(GetComponent<ScoreBoard>().playerOneScore == 10 || GetComponent<ScoreBoard>().playerTwoScore == 10)
        {
            EndGame();
        }
        else
            ResetGame();
    }

    private void EndGame()
    {
        endScreen.SetActive(true);
        if (GetComponent<ScoreBoard>().playerOneScore == 10)
        {
            endScreen.transform.Find("Player# Wins").GetComponent<Text>().text = "Player One Wins";
            endScreen.transform.Find("Player# Wins").GetComponent<Text>().color = new Color(255, 0, 0);
        }
        else
        {
            endScreen.transform.Find("Player# Wins").GetComponent<Text>().text = "Player Two Wins";
            endScreen.transform.Find("Player# Wins").GetComponent<Text>().color = new Color(0, 0, 255);
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
