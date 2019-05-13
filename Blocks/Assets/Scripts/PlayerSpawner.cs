using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;//The prefab that is used to spawn the player
    public List<Vector3> spawnPositions = new List<Vector3>();//Spawn Positions for the Players
    public List<Player> players = new List<Player>();//List that we hold the players in to reference them outside of this script using indexes.

    //Pertains to Materials of the players
    [SerializeField] private Material playerOneMaterial;//The Material that is for player one
    [SerializeField] private Material playerTwoMaterial;//The Material that is for player two.
    public List<Material> materials = new List<Material>();//The List where the above materials are held to apply them to the player using indexes.

    void Start()
    {
        SetSpawnPositions();//Set the spawn positions for the players
        SetMaterials();//Adds the materials to the list
        CreatePlayers();//Spawns the players
    }

    private void CreatePlayers()
    {
        for (int i = 0; i < 2; i++)
        {
            players.Add(Instantiate(
                playerPrefab,
                spawnPositions[i],
                Quaternion.identity).GetComponent<Player>());//Creates a player at a spawn position and adds him to the player list so we can reference him with indexes

            players[i].playerNumber = i;//Sets the player number so we can use it in scripts to determine a player's identity.
            players[i].GetComponentInChildren<MeshRenderer>().material = materials[i];//Sets the proper material for the player so they don't all have the same material
        }
    }

    private void SetSpawnPositions()
    {
        spawnPositions.Add(new Vector3(0, 0.56f, -4));//Player One Spawn Position
        spawnPositions.Add(new Vector3(0, 0.56f, 4));// Player Two Spawn Positon
    }
    private void SetMaterials()
    {
        materials.Add(playerOneMaterial);//Player One Material
        materials.Add(playerTwoMaterial);//Player Two Material
    }
}
