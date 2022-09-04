using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public float waterLevel;

    private float Thirst;
    public float thirst
    {
        get
        {
            return Thirst;
        }
        set
        {
            Thirst = Mathf.Clamp(value, 0, 100);
        }
    }

    public float thirstPerSec;

    private float Energy;
    public float energy
    {
        get
        {
            return Energy;
        }
        set
        {
            Energy = Mathf.Clamp(value, 0, 100);
        }
    }

    public float energyPerSec;

    private GameObject player;
    private Vector3 prevPos;

   
    // Use this for initialization
    void Start()
    {
       
        thirst = 100;
        thirstPerSec = 2f;
        energy = 100;
        energyPerSec = 1f;

        player = GameObject.Find("Player");
        prevPos = player.transform.position;
    }

    public bool wasteWater(float amount)
    {
        if (waterLevel >= amount)
        {
            waterLevel -= amount;
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        thirst -= Time.deltaTime * thirstPerSec;
        energy -= Time.deltaTime * energyPerSec;


    }

    void FixedUpdate()
    {
        thirst -= Vector3.Distance(prevPos, player.transform.position) * 0.1f;
        energy -= Vector3.Distance(prevPos, player.transform.position) * 0.1f;
        prevPos = player.transform.position;
    }
}

