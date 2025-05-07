using UnityEngine;
using System.Collections;

public class TrapStep : MonoBehaviour
{
    private bool isTriggered = false; // Here it should be false flagged because trap isn't triggered/activiated yet.
    

    [SerializeField] private GameObject stairs; // Assign the stairs GameObject in the Inspector with help of the "serializefield" so it will be visible           
    [SerializeField] private AudioSource audioSource;    // This is audio source that plays sound
    [SerializeField] private AudioClip shakeAudioClip;   //This is responsible on sound shaking clip 

    void Start()
    {
       

        if (stairs == null)
            Debug.LogError("TrapStep: Stairs reference is missing!");  // Here its same as first logerror but difference thsi is abt stair gameobj

        if (audioSource == null)
            Debug.LogWarning("TrapStep: AudioSource is not assigned!");  //Here it dont have samme impact as the other "errors", so we consider it as "warning" in console not as "error" bcz not having sound during testing the game will not break the game

         
    }

    void OnTriggerEnter(Collider other)  // When this function gets called, it will pass right away the thing(in our case "player who have a collider that triggers trap") that entered the trigger.
    {
        if (other.CompareTag("Player") && !isTriggered) //checks if its player who going on trap? then check  if trap not triggered so it dont repeats.
        {
            isTriggered = true;      // This here become true when trap is triggered so trap(shake sound here) dont get reapated and triggered without stopping each time player steps on it bcz it will be annoying 
            StartCoroutine(ShakeObject()); // Shaking starts. So aslong as triggerd is true(player detected,trigger activiated), then shaking will start! (using for pausing and resume in other meaning for shaking)
        }
    }

    IEnumerator ShakeObject()    //Preferable to use IEnimerator instead of void becuase shakeobject function should run over multiple frames(so we get better like shaking effect. In case it was void shaking will all happen immeditaly in one frame
    {

        // Audio shaking sound clip starts when stairs shakes. 
             audioSource.clip = shakeAudioClip; 
             audioSource.Play();
        


      

       
        Transform obj = stairs.transform; // Gets tranform object(position) from stairs to be stored in variable obj 
        Vector3 originalPos = obj.position;  // This is being used that after shaking, ogrinal pos of where stairs was will be saved and being putted back.(Original pos is being saved)
        float elapsedTime = 0f;  // It's initialized to be used to track shaking duration (time passed so far)
        float shakeDuration = 1f;
        float shakeAmount = 0.05f; // Shakeamount is littleee bit shaked/rotated 

       //here "while loop" will keep running until shakeduration(1sec) is done.
        while (elapsedTime < shakeDuration)
        {
            obj.position = originalPos + Random.insideUnitSphere * shakeAmount; //  Stairs will be slightly shaked/moved in random direction that will be different from orignal each frame to create the shaking feeling
            elapsedTime += Time.deltaTime; // Adds time passed with each frame to elaspedtime so shake stops after the total reaches shakeduration. So here elpasedTime works as a stopwatch that adds little bit of amount of time every frame until it hits shakeduration.
            yield return null; // This is used  in order to wait for end of current frame before conitunng
        }

        obj.position = originalPos; // Here ofcourse when loop ends,stairs must be restored back to original place. 

    }

}



