using UnityEngine;



using System.Collections;





public class Footsteps : MonoBehaviour


{


    public AudioClip[] outdoorFootsteps;


    public AudioClip[] indoorFootsteps;  // Add indoor footsteps array


    private AudioSource audioSource;


    private CharacterController characterController;


    private float footstepInterval = 0.5f;


    private float lastFootstepTime = -1f;


    private bool isIndoors = false;  // Boolean to check if indoors





    // Add a variable to track the last known position outside


    private Vector3 lastOutdoorPosition;





    void Start()


    {


        audioSource = GetComponent<AudioSource>();


        characterController = GetComponent<CharacterController>();


        audioSource.clip = outdoorFootsteps[Random.Range(0, outdoorFootsteps.Length)];


        lastOutdoorPosition = transform.position;  // Initialize with current position


    }





    void Update()


    {


        bool isMoving = characterController.isGrounded && characterController.velocity.magnitude > 0.5f;


        AudioClip[] currentFootsteps = isIndoors ? indoorFootsteps : outdoorFootsteps;


        audioSource.clip = currentFootsteps[Random.Range(0, currentFootsteps.Length)];





        if (isMoving)


        {


            if (Time.time - lastFootstepTime >= footstepInterval)


            {


                if (!audioSource.isPlaying)


                {


                    audioSource.Play();


                    lastFootstepTime = Time.time;


                }


            }


        }


        else


        {


            if (audioSource.isPlaying)


            {


                if (lastFootstepTime >= 0)


                {


                    StartCoroutine(FadeOut(audioSource, 0.5f));


                }


                lastFootstepTime = -1;


            }


        }


    }





    IEnumerator FadeOut(AudioSource audioSource, float fadeTime)


    {


        float startVolume = audioSource.volume;


        while (audioSource.volume > 0)


        {


            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;


            yield return null;


        }





        audioSource.Stop();


        audioSource.volume = startVolume;


    }





    void OnTriggerEnter(Collider other)


    {


        Debug.Log($"Entered trigger tagged as {other.tag}");


        if (other.CompareTag("Indoor"))


        {


            isIndoors = true;


            lastOutdoorPosition = transform.position; // Update last outdoor position when entering


        }


        else if (other.CompareTag("Outdoor"))


        {


            // Check if exiting: compare entry position with current position


            if (Vector3.Distance(transform.position, lastOutdoorPosition) > 1.0f) // Threshold to determine significant movement


                isIndoors = false;


        }


    }


}