using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static MissionManager;

public class TaskDescription : MonoBehaviour
{

    public MissionManager MM;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (MM.currentDay == 1)
        {
            this.GetComponent<Text>().text = MM.day1M1Desc + " " + (MM.day1Mission1 ? "1" : "0") + "/1\n"
                                           + MM.day1M2Desc + " " + (MM.day1Mission2 ? "1" : "0") + "/1\n"; 
        }
        if (MM.currentDay == 2)
        {
            this.GetComponent<Text>().text = MM.day2M1Desc + " " + (MM.day2Mission1 ? "1" : "0") + "/1\n"
                                           + MM.day2M2Desc + " " + (MM.day2Mission2 ? "1" : "0") + "/1\n"
                                           + MM.day2M3Desc + " " + (MM.day2Mission3 ? "1" : "0") + "/1\n";
        }
        if (MM.currentDay == 3)
        {
            this.GetComponent<Text>().text = MM.day3M1Desc + " " + (MM.day3Mission1 ? "1" : "0") + "/1\n"
                                           + MM.day3M2Desc + " " + (MM.day3Mission2 ? "1" : "0") + "/1\n"
                                           + MM.day3M3Desc + " " + (MM.day3Mission3 ? "1" : "0") + "/1\n"
                                           + MM.day3M4Desc + " " + (MM.day3Mission4 ? "1" : "0") + "/1\n";
        }
    }
}
