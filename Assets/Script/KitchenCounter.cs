using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenCounter : Appliance
{
    public GameObject waterDrop;
    public Transform faucet;
    public GameObject unwashed;
    public GameObject washed_plate;
    public bool isOpen = false;
    public float waterUsage;
    Stats waterHolder;
    private float t;
    public bool washed = false;
    private GameObject[] washSound;
    //private GameObject[] taskComplete;

    // Start is called before the first frame update
    void Start()
    {
        
        unwashed.SetActive(true);
        washed_plate.SetActive(false);
        waterHolder = GameObject.Find("Stats").GetComponent<Stats>();
        washSound = Resources.LoadAll<GameObject>("Sounds/WaterPouring");
        //taskComplete = Resources.LoadAll<GameObject>("Sounds/taskComplete");
    }

    public override void useIt()
    {

        isOpen = !isOpen;
        t = 0;

        if (isOpen == true)
        {
            GameObject audio = Instantiate<GameObject>(washSound[Random.Range(0, washSound.Length)]);
            audio.transform.SetParent(transform);
            audio.transform.position = transform.position;
            audio.name = "PourSound";
        }
        else
        {
            if (transform.Find("PourSound") != null)
                Destroy(transform.Find("PourSound").gameObject);
        }
        //if (washed == true)
        //{
        //    GameObject audio = Instantiate<GameObject>(taskComplete[Random.Range(0, taskComplete.Length)]);
        //    audio.transform.SetParent(transform);
        //    audio.transform.position = transform.position;
        //    audio.name = "taskComplete";
        //}
        washed = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOpen)
        {

            t += Time.deltaTime;
            GameObject water = Instantiate<GameObject>(waterDrop);
            water.transform.localScale = water.transform.localScale;
            water.transform.SetParent(faucet);
            water.transform.position = faucet.position + new Vector3(0, -0.03f, 0);
            water.GetComponent<Rigidbody>().velocity = Vector3.down * 2f;
            
            waterHolder.waterLevel -= waterUsage;
            if (t > 2)
            {
                washed = true;
                //unwashed.SetActive(false);
                //washed_plate.SetActive(true);
            }


        }
        if (washed == true)
        {
            unwashed.SetActive(false);
            washed_plate.SetActive(true);
        }


    }
}
