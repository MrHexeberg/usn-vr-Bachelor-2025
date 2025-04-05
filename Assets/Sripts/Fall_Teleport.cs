using UnityEngine;
using System.Collections;

public class Fall_Teleport : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float teleportDelay = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTrapStatus trapStatus = other.GetComponent<PlayerTrapStatus>();
            if (trapStatus != null && trapStatus.isFallingFromTrap)
            {
                
                StartCoroutine(TeleportAfterDelay(other, trapStatus));
            }
            else
            {
               
            }
        }
    }

    private IEnumerator TeleportAfterDelay(Collider player, PlayerTrapStatus trapStatus)
    {
        yield return new WaitForSeconds(teleportDelay);

        if (player != null)
        {
          
            player.transform.position = respawnPoint.position;

            // Reset fall flag
            trapStatus.ResetTrapFall();
        }
    }
}
