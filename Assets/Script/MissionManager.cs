using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionManager : MonoBehaviour
{
    public int currentDay = 1;
    public bool day1Mission1, day1Mission2 = false;
    public string day1M1Desc = "d1m1"; 
    public string day1M2Desc = "d1m2";
    public bool day2Mission1, day2Mission2, day2Mission3 = false;
    public string day2M1Desc = "d2m1";
    public string day2M2Desc = "d2m2";
    public string day2M3Desc = "d2m3";
    public bool day3Mission1, day3Mission2, day3Mission3, day3Mission4 = false;
    public string day3M1Desc = "d3m1";
    public string day3M2Desc = "d3m2";
    public string day3M3Desc = "d3m3";
    public string day3M4Desc = "d3m4";
    public GameObject gameOverScreen;
    public GameObject gameWin;
    public bool canNextDay = false;
    public Sink sink;
    public Bath bath;
    public Washing washer;
    public Toilet toilet;
    public KitchenCounter kitchen;
    public Text timeMarker;
    public Stats waterHolder;
    // Start is called before the first frame update
    void Start()
    {
        timeMarker.text = "DAY: " + currentDay;
        gameOverScreen.SetActive(false);
        gameWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (waterHolder.energy <= 0 || waterHolder.thirst <= 0 || waterHolder.waterLevel <= 0)
        {
            gameOverScreen.SetActive(true);
        }

        if (currentDay == 4)
        {
            gameWin.SetActive(true);
        }

        if (currentDay == 1)
        {
            if (sink.washed == true)
            {
                day1Mission1 = true;
            }
            if (bath.washed == true)
            {
                day1Mission2 = true;
            }
            if (day1Mission1 && day1Mission2)
            {
                canNextDay = true;
            }
        }

        if (currentDay == 2)
        {
            if (sink.washed == true)
            {
                day2Mission1 = true;
            }
            if (toilet.flushed == true)
            {
                day2Mission2 = true;
            }
            if (kitchen.washed == true)
            {
                day2Mission3 = true;
            }
            if (day2Mission1 && day2Mission2 && day2Mission3)
            {
                canNextDay = true;
            }
        }

        if (currentDay == 3)
        {
            if (sink.washed == true)
            {
                day3Mission1 = true;
            }
            if (toilet.flushed == true)
            {
                day3Mission2 = true;
            }
            if (kitchen.washed == true)
            {
                day3Mission3 = true;
            }
            if (washer.washed == true)
            {
                day3Mission4 = true;
            }
            if (day3Mission1 && day3Mission2 && day3Mission3 && day3Mission4)
            {
                canNextDay = true;
            }
        }

       

        timeMarker.text = "DAY: " + currentDay;
    }
}
