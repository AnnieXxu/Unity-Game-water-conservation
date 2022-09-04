using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    public float dayDuration;
    public float time;
    public float timeOfDay;
    public float waterGain;
    private float waterVelocity;
    Stats waterHolder;
    Vector3 rotation;

    // Use this for initialization
    void Start()
    {
        time = 0;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeOfDay += Time.deltaTime;
        if (timeOfDay > dayDuration)
        {
            timeOfDay = dayDuration - timeOfDay;
            transform.rotation = Quaternion.Euler(0, 330, 0);

        }
        transform.Rotate(Vector3.right, (Time.deltaTime * (360 / dayDuration)));
    }

}
