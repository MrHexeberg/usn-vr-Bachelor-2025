using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{

    bool trig, open;
    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    private Vector3 defaulRot;
    private Vector3 openRot;

    public GameState GameState;
    public int DoorID = 0;
    public bool DoorState = false;


    void Start()
    {

        GameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        defaulRot = transform.eulerAngles;
        openRot = new Vector3(defaulRot.x, defaulRot.y + DoorOpenAngle, defaulRot.z);


    }


    void Update()
    {

        DoorState = GameState.Door[DoorID];
        if (DoorState == true)
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        else
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaulRot, Time.deltaTime * smooth);
        }


    }
}
    