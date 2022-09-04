using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bed : Appliance
{

    Stats statHolder;
    DayNightController time;
    public float energyUp;
    Image fadeBlack;
    public GameObject unwashed_plate;
    public GameObject washed_plate;
    public Washing washing;
    public Toilet toilet;

    //int day = 1;
    //public Text timeMarker;

    public MissionManager xxx;

    void Start()
    {
        statHolder = GameObject.Find("Stats").GetComponent<Stats>();
        time = GameObject.Find("Directional Light").GetComponent<DayNightController>();
        fadeBlack = GameObject.Find("FadeBlack").GetComponent<Image>();
        //timeMarker.text = "DAY: 1";
    }

    public override void useIt()
    {
        float timeDiffrence = time.dayDuration - time.timeOfDay - 0.2f;

        statHolder.energy += energyUp;
        statHolder.thirst -= 20;
        time.time += timeDiffrence;
        time.timeOfDay += timeDiffrence;

        if (xxx.canNextDay)
        {
            xxx.currentDay++;
            unwashed_plate.SetActive(true);
            washed_plate.SetActive(false);
            washing.washed = false;
            washing.isWashing = false;
            toilet.flushed = false;
            statHolder.waterLevel = 100;
            xxx.canNextDay = false;
        }

        StartCoroutine("fadeDelayed", 0.025f);
        


    }
    IEnumerator fadeDelayed(float delay)
    {
        fadeBlack.color = Color.black;
        yield return new WaitForSeconds(delay);
        Color c = fadeBlack.color;
        while (fadeBlack.color.a > 0)
        {
            fadeBlack.color = c;
            c.a -= 0.025f;
            yield return new WaitForSeconds(delay);
        }

        //timeMarker.text = "DAY: " + day;
    }

}
