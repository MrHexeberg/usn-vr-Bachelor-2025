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

        // In Generall having debug errors/warrnings can help alot with testing to identiy the problem fast and solve it. 

        if (rb == null)
            Debug.LogError("TrapStep_Fall: Rigidbody is missing!"); // Here this during testing at first its better to have log errors, so lets say we dont have rightbody on trap so we get error and puzzle will not work. THis is like very important that affects whole puzzle so it needs more attention

        if (stairs == null)
            Debug.LogError("TrapStep_Fall: Stairs reference is missing!"); //  It's same as first logerror but difference  is about stair gameobj. 

        if (audioSource == null)
            Debug.LogWarning("TrapStep_Fall: AudioSource is missing!"); //Here it dont have samme impact as the other "errors", so we consider it as "warning" in console not as "error" bcz not having sound during testing the game will not break the game
    }

    void OnTriggerEnter(Collider other) // When this function gets called, it will pass right away the thing(in our case "player who have a collider that triggers trap") that entered the trigger.
    {
        if (other.CompareTag("Player") && !isTriggered) //checks if its player who going on trap? then check  if trap not triggered so it dont repeats.
        {
            isTriggered = true; // This here become true when trap is triggered so trap(fall here) dont get reapated and triggered without stopping each time player steps on it bcz it will be annoying 
            DropStep();
        }
    }


    void DropStep()
    {
        

        MeshCollider stairMesh = stairs.GetComponentInChildren<MeshCollider>(); // Here we get the mesh collider the is a children of Stairs main obj. Collider on stairs, so player can be able to go on stairs and not just fall whole time..
        

        stairMesh.enabled = false;  // here collider gets disabled 
        StartCoroutine(ReenableStair(stairMesh)); //it gets disabled for 5sec and then reenabled or player cant step on stairs.StarCourtine used to maek the delay and take the function IEnumerator "RenableStair" so it will only be disabled for 5secs. 
       
        // Forcing rigidbody to fall faster downword so trap fall will work. (note rigidbody: it allows gameobj in unity to move with physics).
        rb.isKinematic = false; //here physics affect trap
        rb.useGravity = true;   //Gravity is again applied
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); // Here it means that obj is going downword first, then multipled with 5 so it goes down more and happens quickly.



        // Falling sound starts when player steps on trap and fall
        audioSource.clip = fallSound;
        audioSource.Play();



    }

    // And Here as explained earlier, it will renable collider on s tairs after 5sec. 
    IEnumerator ReenableStair(MeshCollider stairMesh)
    {
        yield return new WaitForSeconds(5f); 

        if (stairMesh != null)
            stairMesh.enabled = true;
    }

   
}
   

   
  
