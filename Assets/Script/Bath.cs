using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bath : Appliance
{
    public GameObject waterDrop;
    public Transform faucet;
    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void useIt()
    {
        isOpen = !isOpen;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            GameObject water = Instantiate<GameObject>(waterDrop);
            water.transform.localScale = water.transform.localScale;
            //water.transform.SetParent(faucet);
            water.transform.position = faucet.position + new Vector3(0, -0.03f, 0);
            //water.GetComponent<Rigidbody>().velocity = Vector3.down * 4f;
        }
    }
}
