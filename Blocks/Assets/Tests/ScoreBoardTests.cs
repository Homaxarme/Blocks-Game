using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.SceneManagement;

public class ScoreBoardTests
{
    [UnityTest]
    public IEnumerator UpdateScores_PointTest()
    {
        Scene testScene = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync("TestLevel", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestLevel"));

        ScoreBoard scoreBoard = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreBoard>();
        scoreBoard.UpdateScores(0);

        Assert.AreEqual(1, scoreBoard.playerTwoScore);

        SceneManager.SetActiveScene(testScene);
        yield return SceneManager.UnloadSceneAsync("TestLevel");
    }
}
