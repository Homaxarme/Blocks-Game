using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerSpawner))]
public class EventManager : MonoBehaviour
{
    [SerializeField] private Material goldMaterial;
    bool canRunGodMode = true;
    private IEnumerator GiveGodMode(int playerNumber)
    {
        canRunGodMode = false;
        Debug.Log("The GodeMode function has started");
        yield return new WaitForSeconds(Random.Range(30,60));
        Debug.Log("The waiting period has ended");
        Player player = GetComponent<PlayerSpawner>().players[playerNumber];
        Material normalMaterial = player.GetComponentInChildren<MeshRenderer>().material;
        player.GetComponent<Rigidbody>().mass = 10;
        player.GetComponentInChildren<MeshRenderer>().material = goldMaterial;
        Debug.Log("God Mode has been assigned");
        yield return new WaitForSeconds(15);

        player.GetComponent<Rigidbody>().mass = 1;
        player.GetComponentInChildren<MeshRenderer>().material = normalMaterial;
        Debug.Log("GodMode has been unassigned");
        canRunGodMode = true;
    }
    private void Update()
    {
        if(canRunGodMode)
        StartCoroutine(GiveGodMode(Random.Range(0, 2)));
    }
}
