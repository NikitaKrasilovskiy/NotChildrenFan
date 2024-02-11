using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("2_Demo");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
