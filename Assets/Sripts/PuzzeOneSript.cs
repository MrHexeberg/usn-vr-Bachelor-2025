using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PuzzeOneSript : MonoBehaviour
{
    public int PartID;
    public string TagWanted;
    
     public PuzzeCollecterSript PuzzeC;
    
    void Start()
    {
        PuzzeC = gameObject.GetComponentInParent<PuzzeCollecterSript>();
        
    }

  

   void OnTriggerEnter(Collider Hitinfo){ // this you will need to edit TagWanted in the inspetor for this to work
        if (Hitinfo.CompareTag(TagWanted))
        {
            PuzzeC.PuzzelPart(PartID,true);
        }
    }
    void OnTriggerExit(Collider Hitinfo){
               if (Hitinfo.CompareTag(TagWanted))
        {
            PuzzeC.PuzzelPart(PartID,false);
        }
    }



}
