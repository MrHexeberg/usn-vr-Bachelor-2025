using System.Collections;
using UnityEngine;

public class TrapStep_Fall : MonoBehaviour
{
    private bool isTriggered = false;
    private Rigidbody rb;

    [SerializeField] private GameObject stairs; 
    [SerializeField] private AudioSource audioSource; 
    [SerializeField] private AudioClip fallSound;     

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
            Debug.LogError("TrapStep_Fall: Rigidbody is missing!");

        if (stairs == null)
            Debug.LogError("TrapStep_Fall: Stairs reference is missing!");

        if (audioSource == null)
            Debug.LogError("TrapStep_Fall: AudioSource is missing!");
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
        if (stairs != null)
            StartCoroutine(ShakeObject(stairs.transform));

        Vector3 originalPosition = transform.position;
        float elapsedTime = 0f;
        float shakeDuration = 0.3f;
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
        if (stairs == null)
            return;

        MeshCollider stairMesh = stairs.GetComponentInChildren<MeshCollider>();
        if (stairMesh == null)
            return;

        stairMesh.enabled = false;
        StartCoroutine(ReenableStair(stairMesh));
        StartCoroutine(ResetTriggerCooldown());

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        
        if (audioSource != null && fallSound != null)
        {
            audioSource.clip = fallSound;
            audioSource.Play();
        }

        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.SendMessage("MarkAsFallingFromTrap", SendMessageOptions.DontRequireReceiver);
        }
    }

    IEnumerator ReenableStair(MeshCollider stairMesh)
    {
        yield return new WaitForSeconds(5f);

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
        float shakeDuration = 1f;
        float shakeAmount = 0.05f;

        while (elapsedTime < shakeDuration)
        {
            obj.position = originalPos + Random.insideUnitSphere * shakeAmount;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.position = originalPos;
    }

   
    public void SetVolume(float volume)
    {
        if (audioSource != null)
            audioSource.volume = volume;
    }
}
