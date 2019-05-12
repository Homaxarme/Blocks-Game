using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextDisplayer : MonoBehaviour
{
    public void UpdateValues(string _text)
    {
        //Updates the Text
        GetComponent<Text>().text = _text;        
    }
}
