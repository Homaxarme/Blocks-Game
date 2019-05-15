using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Script needs a transform to detect player position, the PlayerMovement script to kill input, and the Player script to report the death to the Game Manager.
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Player))]
public class PlayerDeathScript : MonoBehaviour
{
    private void Update()
    {
        //If the player is dead, the code will not run. This is to prevent a stack overflow.
        if(!GetComponent<Player>().isDead)
        {
            if (PlayerOutOfBounds())
            {
                GetComponent<Player>().isDead = true; //Kills the player so that this code block won't run another time.
                GetComponent<PlayerMovement>().enabled = false; //Kills player input script
                ReportDeath();//Tells the ScoreBoard that the player has died
            }
        }
    }
    //Figures out if the Player has gone out of bounds.
    private bool PlayerOutOfBounds()
    {
        Transform transform = GetComponent<Transform>();
        if (transform.position.x > 6 || transform.position.x < -6 || transform.position.z > 6 || transform.position.z < -6)
            return true;
        else
            return false;
    }
    //Tells scoreboard that the player died.
    private void ReportDeath()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreBoard>().UpdateScores(GetComponent<Player>().playerNumber);
        Debug.Log("Player " + GetComponent<Player>().playerNumber.ToString() + " has died. This has been reported to the GameManager.");
    }
}