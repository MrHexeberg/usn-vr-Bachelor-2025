using UnityEngine;
using System.Collections;

public class TrapStep : MonoBehaviour
{
    private bool isTriggered = false;
    private Rigidbody rb;

    [SerializeField] private GameObject stairs; // Assign the stairs GameObject in the Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
            Debug.LogError("TrapStep: Rigidbody is missing!");

        if (stairs == null)
            Debug.LogError("TrapStep: Stairs reference is missing!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(ShakeStep());
        }
    }

    IEnumerator ShakeStep()
    {
        // Start shaking stairs
        if (stairs)
            StartCoroutine(ShakeObject(stairs.transform));

        // Slight shake of this step before falling
        Vector3 originalPosition = transform.position;
        float elapsedTime = 0f;
        float shakeDuration = 1f;
        float shakeAmount = 0.05f;

        while (elapsedTime < shakeDuration)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeAmount;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        DropStep();
    }

    void DropStep()
    {
        // Disable stairs' collider so player falls
        MeshCollider stairMesh = stairs.GetComponent<MeshCollider>();
        if (stairMesh != null)
            stairMesh.enabled = false;

        // Re-enable collider later
        StartCoroutine(ReenableStair(stairs));
        StartCoroutine(ResetTriggerCooldown());

        // Make the trap fall
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
    }

    IEnumerator ReenableStair(GameObject stair)
    {
        yield return new WaitForSeconds(5f);

        MeshCollider stairMesh = stair.GetComponent<MeshCollider>();
        if (stairMesh != null)
            stairMesh.enabled = true;
    }

    IEnumerator ResetTriggerCooldown(float delay = 5f)
    {
        yield return new WaitForSeconds(delay);
        isTriggered = false;
    }

    IEnumerator ShakeObject(Transform obj)
    {
        Vector3 originalPos = obj.position;
        float elapsedTime = 0f;
        float shakeDuration = 1.5f;
        float shakeAmount = 0.05f;

        while (elapsedTime < shakeDuration)
        {
            obj.position = originalPos + Random.insideUnitSphere * shakeAmount;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.position = originalPos;
    }
}

