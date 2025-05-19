using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player; // Player's head( also known as vrcamera where player spwans..)

    void Update()
    {
        // Calculates the direction from the NPC to the player
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // This keeps the NPC's head level without tilting up or down. So npc will not try to rotate his head down or up. so we just lock y component. That mneans only can rotate left and right.

        
        Quaternion rotation = Quaternion.LookRotation(direction); // // It's the rotation needed that faces player


        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);  // // transform.rotation is current roation of npc . So by using Quatnrion.slerp, rotation starts from transform.rotation to  lookRotation(where player is looking) where speed of rotation is controller by Time.deltaTime*5
    }
}
