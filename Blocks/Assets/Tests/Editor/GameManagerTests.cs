using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.UI;
public class GameManagerTests
{
    [Test]
    public void TestScoreUpdate()
    {
        GameObject textHolder = new GameObject();
        Text text = textHolder.AddComponent<Text>();
        TextDisplayer textDisplayer = textHolder.AddComponent<TextDisplayer>();

        ScoreBoard scoreBoard = new GameObject().AddComponent<ScoreBoard>();

        scoreBoard.ScoreUpdate(1);
        int result = scoreBoard.PlayerTwoScore;

        Assert.AreEqual(1, result);
    }
}
