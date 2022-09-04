using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : Appliance
{
    public float waterUsage;
    Stats waterHolder;
    public bool drink = false;

    public float thirstUp;
    public AudioClip drinkSound;

    void Start()
    {
        waterHolder = GameObject.Find("Stats").GetComponent<Stats>();
    }

    public override void useIt()
    {
        //drink = !drink;
        waterHolder.waterLevel -= waterUsage;
        waterHolder.thirst += thirstUp;
        AudioSource.PlayClipAtPoint(drinkSound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //if (drink)
        //{
        //    waterHolder.waterLevel -= waterUsage;
        //    waterHolder.thirst += thirstUp;
        //}

    }
}
