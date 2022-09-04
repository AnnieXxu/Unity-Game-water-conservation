using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : Appliance
{
    public GameObject waterDrop;
    public Transform faucet;
    public float waterUsage;
    Stats waterHolder;
    private float t;
    public bool flushed = false;
    public AudioClip flushSound;
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        waterHolder = GameObject.Find("Stats").GetComponent<Stats>();
    }

    public override void useIt()
    {
        isOpen = true;
        AudioSource.PlayClipAtPoint(flushSound, transform.position);
        t = 0;
        flushed = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isOpen == true)
        {
            t += Time.deltaTime;
            GameObject water = Instantiate<GameObject>(waterDrop);
            water.transform.localScale = water.transform.localScale;
            water.transform.SetParent(faucet);
            water.transform.position = faucet.position + new Vector3(0, -0.03f, 0);
            water.GetComponent<Rigidbody>().velocity = Vector3.down * 4f;
            waterHolder.waterLevel -= waterUsage;
            if (t > 1)
            {
                flushed = true;
                isOpen = false;
            }
        }
        
    }
}