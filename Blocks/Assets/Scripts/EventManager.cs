using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
[RequireComponent(typeof(PlayerSpawner))]
public class EventManager : MonoBehaviour
{
    private RNGCryptoServiceProvider randomGenerator = new RNGCryptoServiceProvider();
    [SerializeField] private Material goldMaterial;
    private bool canRunGodMode = true;
    private void Update()
    {
        if (canRunGodMode)
            StartCoroutine(GodModeManager(GetRandom()));
    }
    private IEnumerator GodModeManager(int playerNumber)
    {
        canRunGodMode = false;

        yield return new WaitForSeconds(1);

        Player player = GetComponent<PlayerSpawner>().players[playerNumber];
        Material normalMaterial = player.GetComponentInChildren<MeshRenderer>().material;
        EnableGodMode(player);

        yield return new WaitForSeconds(15);
        DisableGodMode(player, normalMaterial);
        canRunGodMode = true;
    }
    private void EnableGodMode(Player player)
    {
        //Make the player a god
        player.GetComponent<PlayerMovement>().force = 75;
        player.GetComponent<Rigidbody>().mass = 100;
        player.GetComponentInChildren<MeshRenderer>().material = goldMaterial;
    }

    private static void DisableGodMode(Player player, Material normalMaterial)
    {
        player.GetComponent<Rigidbody>().mass = 1;
        player.GetComponent<PlayerMovement>().force = 100;
        player.GetComponentInChildren<MeshRenderer>().material = normalMaterial;
    }
    private int GetRandom()
    {
        byte[] randomNumber = new byte[1];
        randomGenerator.GetBytes(randomNumber);
        return (int)randomNumber[0] % 2;
    }
}
