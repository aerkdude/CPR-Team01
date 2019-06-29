using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    /*public GameObject TeleportMarker;
    public Transform Player;
    public float RayLength = 50f;

    void Start()
    {
        OVRTouchPad.Create();
        OVRTouchPad.TouchHandler += TouchpadHandler;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.foward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, RayLength))
        {
            if (hit.collider.tag == "Ground")
            {
                if(!TeleportMarker.activeSelf)
                {
                    TeleportMarker.SetActive(true);
                }
                TeleportMarker.transform.position = hit.point;
            }
        }
    }
    
    void TouchpadHandler(object sender, System.EventArgs e)
    {
        OVRTouchPad.TouchArgs args = (OVRTouchPad.TouchArgs)e;
        if(args.TouchType == OVRTouchPad.TouchEvent.SingleTap)
        {

        }
    }*/
}
