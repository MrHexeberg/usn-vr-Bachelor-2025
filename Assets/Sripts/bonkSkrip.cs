using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonkSkrip : MonoBehaviour
{


    [SerializeField] private AudioClip DoorHead;


    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = DoorHead;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider Hitinfo)
    {
        if (Hitinfo.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}

