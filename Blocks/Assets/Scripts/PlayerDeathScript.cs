using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The Script needs a transform to detect player position, the PlayerMovement script to kill input, and the Player script to report the death to the Game Manager.
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Player))]
public class PlayerDeathScript : MonoBehaviour
{
    // Declares the objects needed
    Player player;
    Transform transform;
    PlayerMovement movementScript;
    ScoreBoard gameController;

    //If the player has died or not
    bool playerDead;

    private void Start()
    {
        //Set the variables to the relevant objects
        player = GetComponent<Player>();
        transform = GetComponent<Transform>();
        movementScript = GetComponent<PlayerMovement>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreBoard>();
        playerDead = false;

    }
    // Update is called once per frame
    void Update()
    {
        //If the player is dead, the code will not run. This is to prevent a stack overflow.
        if(!playerDead)
        {
            if (PlayerOutOfBounds())
            {
                playerDead = true; //Kills the player so that this code block won't run another time.
                movementScript.enabled = false; //Kills player input script
                ReportDeath();//Tells the game Manager that the player has died
                gameController.InvokeRestartLevel();
            }
        }
    }

    bool PlayerOutOfBounds()
    {
        if (transform.position.y <= 0)
            return true;
        else
            return false;
    }
    void ReportDeath()
    {
        gameController.ScoreUpdate(player.playerNumber);
        Debug.Log("Player " + player.playerNumber.ToString() + " has died. This has been reported to the GameManager.");
    }
}
