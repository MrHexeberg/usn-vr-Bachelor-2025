using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{

    public float Speed = 2.0f;
    public float DoorOpenAngle = 90.0f;
    
    public GameState GameState;
    public int DoorID = 0;
    public bool DoorState;
    
    [SerializeField] private AudioClip DoorAudioOpen;
    [SerializeField] private AudioClip DoorAudioClose;

    private AudioSource audioSource;
    private Vector3 defaulRot;
    private Vector3 openRot;



    void Start()
    {

        GameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        defaulRot = transform.eulerAngles;
        openRot = new Vector3(defaulRot.x, defaulRot.y + DoorOpenAngle, defaulRot.z);
        
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = DoorAudioClose;


    }


    void FixedUpdate()
    {

        DoorState = GameState.Door[DoorID];
        if (DoorState == true)
        {
            DoorOpen();
        }
        else
        {
            DoorClose();
        }
    }




    public void DoorOpen()// this transform the angle of the door a small amount every time it get called and playes the audio audio clip
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * Speed); // the amount that the door is transformed per fram
       if (audioSource.clip != DoorAudioOpen){
        audioSource.Stop(); 
        audioSource.clip = DoorAudioOpen;
        audioSource.Play();
       }
    }
    public void DoorClose()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaulRot, Time.deltaTime * Speed);
        if (audioSource.clip != DoorAudioClose){
        audioSource.Stop();
        audioSource.clip = DoorAudioClose;
        audioSource.Play();
        }
    }
}
