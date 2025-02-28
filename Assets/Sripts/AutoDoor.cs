using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : Door
{
   
    void FixedUpdate()
    {
    if (DoorState == true)
        {
            DoorOpen();
        }
        else
        {
            DoorClose();
        }

    }

    void OnTriggerEnter(Collider Hitinfo){
        if (Hitinfo.CompareTag("Player"))
        {
            DoorState = true;
        }
    }
    void OnTriggerExit(Collider Hitinfo){
               if (Hitinfo.CompareTag("Player"))
        {
            DoorState = false;
        }
    }


}
