using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{

    TextController textController;
    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    void Start()
    {
        textController = FindObjectOfType<TextController>();
    }
    private void UpdateScoreBoard()
    {
        textController.UpdateValues();
    }
    public void DeathReported(int playerNumber)
    {
        if(playerNumber == 1)
            playerTwoScore++;
        else
            playerOneScore++;
        UpdateScoreBoard();
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Will call the Restart Method
    public void InvokeRestartLevel()
    {
        Invoke("RestartLevel", 2f);
    }
}
