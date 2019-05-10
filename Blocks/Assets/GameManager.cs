using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Used for creating the objects
    [SerializeField]private GameObject playerPrefab;//Player Objects to Spawn
    private List<Vector3> spawnPositions = new List<Vector3>();//Spawn Positions for the Players
    private List<Player> players = new List<Player>();//List for the Players

    void Start()
    {
        SetSpawnPositions();//Set the spawn positions for the players
        CreatePlayers();//Spawns the players
    }
    /// <summary>
    /// Sets the position of a player back to their spawn point
    /// </summary>
    /// <param name="playerNumber"></param> This is the player which will be affected
    private void ResetPositionOfPlayer(int playerNumber)
    {
        players[playerNumber].GetComponent<Transform>().SetPositionAndRotation(
            spawnPositions[playerNumber],
            Quaternion.identity);
    }
    public void InvokeResetPosition(int playerNumber)
    {

    }
    /// <summary>
    /// Instantiates all the player objects to their corresponding spawn position
    /// </summary>
    private void CreatePlayers()
    {
        for (int i = 0; i < 2; i++)
        {
            players.Add(Instantiate(
                playerPrefab,
                spawnPositions[i],
                Quaternion.identity).GetComponent<Player>());

            players[i].playerNumber = i;
        }
    }
    /// <summary>
    /// Sets the spawn positions for the players.
    /// </summary>
    private void SetSpawnPositions()
    {
        spawnPositions.Add(new Vector3(0, 0.56f, 4));
        spawnPositions.Add(new Vector3(0, 0.56f, -4));
    }
}
