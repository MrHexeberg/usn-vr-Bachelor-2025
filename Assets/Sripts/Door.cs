using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{

    public float Speed = 2.0f;
    public float DoorOpenAngle = 90.0f;


    private Vector3 defaulRot;
    private Vector3 openRot;

    public GameState GameState;
    public int DoorID = 0;
    public bool DoorState;


    void Start()
    {

        GameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        defaulRot = transform.eulerAngles;
        openRot = new Vector3(defaulRot.x, defaulRot.y + DoorOpenAngle, defaulRot.z);


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




    public void DoorOpen()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * Speed);
    }
    public void DoorClose()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaulRot, Time.deltaTime * Speed);
    }
}
