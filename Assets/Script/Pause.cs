using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour
{


    DayNightController time;

    // Use this for initialization
    void Start()
    {
        PauseGame();
        time = GameObject.Find("Directional Light").GetComponent<DayNightController>();
        GameObject.Find("FadeBlack").SetActive(false);
        GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public static bool IsPaused()
    {
        return Time.timeScale == 0;
    }

    public void mainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("Menu");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
