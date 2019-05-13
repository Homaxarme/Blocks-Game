using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(GameRestarter))]
public class ScoreBoard : MonoBehaviour
{

    public int playerOneScore = 0;//The score that the first player has
    public int playerTwoScore = 0;//The score that the second player has
    public bool isGameEnded = false;//If a player reports his death, the game ends and the ScoreBoard will no longer count points until the game restarts.

    public void UpdateScores(int playerNumber)
    {
        if (!isGameEnded)
        {
            if (playerNumber == 0)
                playerTwoScore++;
            else
                playerOneScore++;
            GameObject.Find("Score").GetComponent<TextDisplayer>().UpdateValues(playerOneScore.ToString() + "-" + playerTwoScore.ToString());
            isGameEnded = true;
            StartCoroutine(GetComponent<GameRestarter>().UpdateGameState());
        }
    }
}
