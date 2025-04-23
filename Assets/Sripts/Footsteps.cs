using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [Header("Audio Components")]
    [SerializeField] private AudioSource audioSource;

    [Header("Footstep Clips")]
    [SerializeField] private AudioClip outdoorFootstepClip;
    [SerializeField] private AudioClip indoorFootstepClip;

    [Header("Footstep Timing")]
    [SerializeField] private float footstepInterval = 0.5f;

    private CharacterController characterController;
    private float lastFootstepTime = -1f;
    private bool isIndoors = false;

public Rigidbody rb;

    [SerializeField] private float speed;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()

        //characterController.isGrounded &&
    {
        bool isMoving =  characterController.velocity.magnitude > 0.5f;
        speed = characterController.velocity.magnitude;

        if (isMoving)
        {
            if (Time.time - lastFootstepTime >= footstepInterval)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = isIndoors ? indoorFootstepClip : outdoorFootstepClip;
                    audioSource.Play();
                    lastFootstepTime = Time.time;
                }
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                lastFootstepTime = -1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Indoor"))
        {
            isIndoors = true;
        }
        else if (other.CompareTag("Outdoor"))
        {
            isIndoors = false;
        }
    }
}
