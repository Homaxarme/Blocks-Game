using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKey("escape"))
        {
            Debug.Log("Application has been quit!");
            Application.Quit();
        }
    }
}
