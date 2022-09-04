using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingGame : MonoBehaviour
{
    [System.Obsolete]
    public void LoadGame()
    {
        Application.LoadLevel("MainScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
