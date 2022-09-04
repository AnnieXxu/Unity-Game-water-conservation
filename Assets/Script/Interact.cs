using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject crossHair;
    public GameObject cursor;
    private RaycastHit raycasthit;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//Lock cursor
        //transform.GetChild(0).localPosition = new Vector3(0, 0, 0.5f);//initalize crosshair pos
    }

    void Update()
    {
        var layerMask = (1 << 4) + (5 << 8);
        if ((Physics.Raycast(this.transform.position, this.transform.forward, out raycasthit, 5f, ~layerMask)) && (raycasthit.collider.gameObject.CompareTag("Appliance")))
        {
            crossHair.SetActive(false);
            cursor.SetActive(true);
            if (Input.GetMouseButtonUp(0))//left click
            {
                EmissionRay();
            }
        }
        else
        {
            crossHair.SetActive(true);
            cursor.SetActive(false);
        }
 
    }

    private void EmissionRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out raycasthit))
        {
            foreach (Appliance x in raycasthit.collider.GetComponents<Appliance>())
            {
                x.useIt();
            }
        }
    }
}
