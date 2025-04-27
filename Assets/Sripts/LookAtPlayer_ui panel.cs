
using UnityEngine;

public class LookAtPlayer_uipanel : MonoBehaviour
{

    public Transform playerCamera; // Assign the player's camera here in the inspector that coressponds to his head so we know what camera its

    void Update()   
    {
        //Calculate direction from player's camera to this obj(so panel faces player)
        Vector3 direction = transform.position - playerCamera.position; 
        
        
        direction.y = 0;  // Neutralize the y component to prevent panel from going up or down

        
        Quaternion lookRotation = Quaternion.LookRotation(direction);  // It's the rotation created that faces player. 

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5); // transform.rotation is current roation of npc panel. So by using Quatnrion.slerp, rotation starts from transform.rotation to  lookRotation(where player is looking) where speed of rotation is controller by Time.deltaTime*5
    }
}