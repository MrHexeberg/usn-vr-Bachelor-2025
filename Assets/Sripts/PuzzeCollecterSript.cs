using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PuzzeCollecterSript : MonoBehaviour
{
    public int PuzzelID;

    public bool[] Parts = {false};
     public GameState GameState;
    

    void Start()
    {
        GameState = gameObject.GetComponentInParent<GameState>(); 
        // this script need to be a child of an object with the GameState sript on it 
    
    }


    public void PuzzelPart(int PartID,bool State){
        Parts[PartID] = State;
       
        for (int i = 0; i < Parts.Length; i++){
            if (Parts[i] == false){
                GameState.PuzzelUnSolved(PuzzelID);
                break;
            }
            else if (Parts[i] == true && i == Parts.Length-1){
                 GameState.PuzzelSolved(PuzzelID);
            }
        }

    }
}
