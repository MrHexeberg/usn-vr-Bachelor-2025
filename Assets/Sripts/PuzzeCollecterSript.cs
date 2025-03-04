using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PuzzeCollecterSript : MonoBehaviour
{
    public int PuzzelID;

    public bool[] Parts = {false};
     public GameState GameState;
    // Start is called before the first frame update
    void Start()
    {
        GameState = gameObject.GetComponentInParent<GameState>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
