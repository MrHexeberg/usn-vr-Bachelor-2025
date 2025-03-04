using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player; //players head(aka vrcamera where player spwans..)

    void Update()
    {
        // Calculates the direction from the NPC to the player
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // This keeps the NPC's head level without tilting up or down

        // this here creates a rotation that looks along the aforementioned direction
        Quaternion rotation = Quaternion.LookRotation(direction);

        // here this will Smoothly rotate the NPC's transform towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
    }
}
