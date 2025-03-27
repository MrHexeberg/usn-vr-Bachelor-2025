
using UnityEngine;

public class LookAtPlayer_uipanel : MonoBehaviour
{

    public Transform playerCamera; // Assign the player's camera here in the inspector

    void Update()  //beregner her retnignn fra spillerens camera til dette objektet(panel-så sånn blir panaelen vendt mot spilleren..)
    {
        Vector3 direction = transform.position - playerCamera.position; // Reverse the direction to face towards the player
        
        
        direction.y = 0; // // Nøytraliser den vertikale komponenten av retningen for å forhindre at panelet vipper opp eller ned

        
        Quaternion lookRotation = Quaternion.LookRotation(direction); //dette sikrrer at teksten blir ikke reverset når panalen roteerer seg

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
}