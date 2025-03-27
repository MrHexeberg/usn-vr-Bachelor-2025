using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public bool[] Door = { false, false, false, false, };
    public bool[] Puzzel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void PuzzelSolved(int PuzzelID)
    {
        Door[PuzzelID] = true;
    }
    public void PuzzelUnSolved(int PuzzelID){
        Door[PuzzelID] = false;
    }
}
