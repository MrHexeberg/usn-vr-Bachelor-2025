using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource audioSource;  // This works like a speaker. if we want sound we need this audiosource component in unity
    [SerializeField] private AudioClip WoodAudioPointer;

    void Start()
    {

        audioSource.loop = true;  // We want background music to be loop so it don't stop when clip is over, becasue it's a background music, it should keep going and going 
        audioSource.clip = WoodAudioPointer;
        audioSource.Play();
       
    }


    
}
    

    
