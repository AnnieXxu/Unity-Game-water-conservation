using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Appliance
{
    private Transform m_Transform;
    public AudioClip openSound;
    public AudioClip closeSound;
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = this.GetComponent<Transform>();
    }

    public override void useIt()
    {
        if (isOpen)
        {
            CloseDoor();
        } else
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        m_Transform.Rotate(Vector3.up, -90);
        isOpen = true;
        AudioSource.PlayClipAtPoint(openSound, transform.position);
    }
    private void CloseDoor()
    {
        m_Transform.Rotate(Vector3.up, 90);
        isOpen = false;
        AudioSource.PlayClipAtPoint(closeSound, transform.position);
    }
 
}
