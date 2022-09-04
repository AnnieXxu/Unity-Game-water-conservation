using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washing : Appliance
{
    public GameObject unwashed;
    public GameObject washed_cloths;
    public bool washed = false;
    public bool isOpen = false;
    public bool isWashing = false;
    public float waterUsage;
    Stats waterHolder;
    private float t;
    private GameObject[] washSound;
    public AudioClip taskComplete;
    public MissionManager mm;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        
            
        waterHolder = GameObject.Find("Stats").GetComponent<Stats>();
        washSound = Resources.LoadAll<GameObject>("Sounds/washingClothes");
    }

    public override void useIt()
    {
        if (washed == false && isWashing==false && mm.currentDay==3) 
        {
            isOpen = !isOpen;
            t = 0;
            waterHolder.waterLevel -= waterUsage;
        }
        
        if (isOpen == true && isWashing == false)
        {
            GameObject audio = Instantiate<GameObject>(washSound[Random.Range(0, washSound.Length)]);
            audio.transform.SetParent(transform);
            audio.transform.position = transform.position;
            audio.name = "washingClothes";
        }
 
        
    }
    // Update is called once per frame
    void Update()
    {

        if (washed == false && isWashing == false)
        {
            unwashed.SetActive(true);
            washed_cloths.SetActive(false);
        }
        if (isWashing == true)
        {
            unwashed.SetActive(false);
            washed_cloths.SetActive(true);
        }
        if (isOpen)
        {
            t += Time.deltaTime;
            isWashing = true;
            
            if (t > 7)
            {
                washed = true;
                unwashed.SetActive(false);
                washed_cloths.SetActive(false);
                if (transform.Find("washingClothes") != null) 
                {
                    Destroy(transform.Find("washingClothes").gameObject);
                }
                //AudioSource.PlayClipAtPoint(taskComplete, transform.position);

            }
        }


    }
}
