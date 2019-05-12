using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerSpawner))]
public class GameRestarter : MonoBehaviour
{

    /// <summary>
    /// Sets the position of a player back to their spawn point
    /// </summary>
    /// <param name="playerNumber"></param> This is the player which will be affected
    private void ResetPositionOfPlayers(int playerNumber)
    {
            GetComponent<PlayerSpawner>().players[playerNumber].transform.SetPositionAndRotation(GetComponent<PlayerSpawner>().spawnPositions[playerNumber], Quaternion.identity);
    }
    public IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(2);

        for(int i = 0; i < GetComponent<PlayerSpawner>().players.Count; i++)
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
