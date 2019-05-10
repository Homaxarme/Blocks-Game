using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextDisplayer : MonoBehaviour
{
    Text text;
    void Start()
    {
        //Retrieves the text object
        text = GetComponent<Text>();
    }
    //Method that other functions can call to update the text
    public void UpdateValues(string _text)
    {
        //Updates the Text
        text.text = _text;        
    }
}
