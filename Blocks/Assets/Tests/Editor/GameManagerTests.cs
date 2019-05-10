using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class GameManagerTests
{
    [Test]
    public void TestScoreUpdate()
    {
        TextController textController = new GameObject().AddComponent<TextController>();
        GameController gameManager = new GameObject().AddComponent<GameController>();

        gameManager.DeathReported(1);
        int result = gameManager.playerTwoScore;

        Assert.AreEqual(1, result);
    }
}
