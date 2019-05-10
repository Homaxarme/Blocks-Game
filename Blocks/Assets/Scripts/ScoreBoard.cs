using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    private TextDisplayer textDisplayer;
    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    void Start()
    {
        textDisplayer = FindObjectOfType<TextDisplayer>();
    }
    public void ScoreUpdate(int playerNumber)
    {
        if(playerNumber == 1)
            playerTwoScore++;
        else
            playerOneScore++;
        textDisplayer.UpdateValues(playerOneScore.ToString() + "-" + playerTwoScore.ToString());
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
