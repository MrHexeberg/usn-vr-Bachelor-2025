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
           
            StartCoroutine(TeleportAfterDelay(other));
        }
    }

    private IEnumerator TeleportAfterDelay(Collider player)
    {
        yield return new WaitForSeconds(teleportDelay);

        if (player != null)
        {
           
            player.transform.position = respawnPoint.position;
        }
    }
}
