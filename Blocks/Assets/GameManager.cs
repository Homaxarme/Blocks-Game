using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform PlayerOne;
    public Transform PlayerTwo;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (PlayerOne.position.y < -1)
        {
            Restart();
        }
        if (PlayerTwo.position.y <-1)
        {
            Restart();
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
