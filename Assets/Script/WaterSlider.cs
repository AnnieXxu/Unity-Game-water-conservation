using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaterSlider : MonoBehaviour
{
    Slider slider;
    //Text text;
    Stats waterHolder;

    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        //text = GetComponentInChildren<Text>();
        waterHolder = GameObject.Find("Stats").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = waterHolder.waterLevel / 100;
        //Debug.Log(text);
        //text.text = ((int)waterHolder.waterLevel).ToString();
    }
}
