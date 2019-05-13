using UnityEngine.TestTools;
using System.Collections;
using NUnit.Framework;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TextDisplayerTests
{
    [UnityTest]
    public IEnumerator UpdateValuesTest()
    {
        Scene testScene = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync("TestLevel", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestLevel"));

        TextDisplayer textDisplayer = GameObject.Find("Score").GetComponent<TextDisplayer>();
        textDisplayer.UpdateValues("Hello World!");

        Assert.AreEqual("Hello World!", GameObject.Find("Score").GetComponent<Text>().text);

        SceneManager.SetActiveScene(testScene);
        yield return SceneManager.UnloadSceneAsync("TestLevel");
    }
}
