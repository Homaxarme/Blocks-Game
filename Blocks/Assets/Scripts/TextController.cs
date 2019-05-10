using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextController : MonoBehaviour
{
    Text text;
    GameController gameManager;

    void Start()
    {
        //Sets the first two objects
        text = GetComponent<Text>();
        gameManager = FindObjectOfType<GameController>();
    }
    public void UpdateValues()
    {
        //The script looks inside the GameManager and retrieves the scores
        //Then it sets the scores
        text.text = gameManager.playerOneScore.ToString() + "-" + gameManager.playerTwoScore.ToString();

        Debug.Log("The score has been updated.");
    }
}
