using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Appliance
{
    public GameObject waterDrop;
    public Transform faucet;
    public float waterUsage;
    private float t;
    public bool washed = false;
    Stats waterHolder;
    private GameObject[] washSound;

    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        waterHolder = GameObject.Find("Stats").GetComponent<Stats>();
        washSound = Resources.LoadAll<GameObject>("Sounds/WaterPouring");
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
        washed = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            t += Time.deltaTime;
            GameObject water = Instantiate<GameObject>(waterDrop);
            water.transform.localScale = water.transform.localScale;
            water.transform.SetParent(faucet);
            water.transform.position = faucet.position + new Vector3(0, -0.03f, 0);
            water.GetComponent<Rigidbody>().velocity = Vector3.down * 4f;
            waterHolder.waterLevel -= waterUsage;
            if (t > 2)
            {
                washed = true;
            }
        }

    }
}
