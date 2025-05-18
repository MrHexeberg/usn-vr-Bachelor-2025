using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : Door
{
   
    void FixedUpdate()
    {
    if (DoorState == true)
        {
            DoorOpen(); // this called function that is inhereted from the Door script 
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
