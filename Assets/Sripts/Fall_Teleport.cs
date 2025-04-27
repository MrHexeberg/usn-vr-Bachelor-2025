using UnityEngine;
using System.Collections;

public class Fall_Teleport : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint; // Player will telport to this area after falling from stairs(respawnPoint is infront of stairs-like a fixed point). In addition, it's Serializefield bcz its private, so it can be visible in unity inspector eventhough its priavate so other scripts/things in game can't interact with it.. bcz when it's private+serializefield variable can't be used from anyscript and at same time it can be assgined in Inspector.
    [SerializeField] private float teleportDelay = 5f; // Delay duration before telporting. 5sec waiting time before telporting.

   
    private void OnTriggerEnter(Collider other) // Function here being called when "other/anyobj enters" (Player we want in our case) enters trapzone area
    {
        if (other.CompareTag("Player")) //Check if its Player who is walking at the momment they touch trigger
        {
            
            StartCoroutine(TeleportAfterDelay(other));  // StartCoroutine is used to start the paussable function (TeleportAfterDelay) so its like paused. "Other" collider is being passedd(the player) bcz after waiting 5secs, function will know that its the player that will need to be teleportated so we are tracking the correct player that triggered telporation 
        }
    }

    
    private IEnumerator TeleportAfterDelay(Collider player) // Here using IEnumerator allows function to be able to pause function and then resume it. collding with variable player
    {
        yield return new WaitForSeconds(teleportDelay); // Pauses function until 5secdelay passes. bcz we don't want the player immeditaly telportes to respawn area.. we need 5sec delay or it will be annoying for player 

       

            player.transform.position = respawnPoint.position; // Here player gets telported after the delay. 
        
    }
}
