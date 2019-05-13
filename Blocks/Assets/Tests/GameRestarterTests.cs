using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GameRestarterTests
{
    [UnityTest]
    public IEnumerator TestRepositoning()
    {
        Scene testScene = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync("TestLevel", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestLevel"));

        GameRestarter gameRestarter = GameObject.FindWithTag("GameController").GetComponent<GameRestarter>();
        List<Player> playerList = GameObject.FindWithTag("GameController").GetComponent<PlayerSpawner>().players;
        List<Vector3> spawnPositions = GameObject.FindWithTag("GameController").GetComponent<PlayerSpawner>().spawnPositions;

        bool playersHaveBeenReset = true;
        gameRestarter.UpdateGameState();

        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i].transform.position != spawnPositions[i])
            {
                playersHaveBeenReset = false;
            }
        }
        Assert.AreEqual(true, playersHaveBeenReset);

        SceneManager.SetActiveScene(testScene);
        yield return SceneManager.UnloadSceneAsync("TestLevel");
    }
    [UnityTest]
    public IEnumerator TestReviving()
    {
        Scene testScene = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync("TestLevel", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestLevel"));

        GameRestarter gameRestarter = GameObject.FindWithTag("GameController").GetComponent<GameRestarter>();
        List<Player> playerList = GameObject.FindWithTag("GameController").GetComponent<PlayerSpawner>().players;

        bool playersAreAlive = true;
        for (int i = 0; i < playerList.Count; i++)
        {
            playerList[i].isDead = true;
        }
        gameRestarter.UpdateGameState();
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i].isDead)
            {
                playersAreAlive = false;
            }
        }
        Assert.AreEqual(true, playersAreAlive);

        SceneManager.SetActiveScene(testScene);
        yield return SceneManager.UnloadSceneAsync("TestLevel");
    }
}
