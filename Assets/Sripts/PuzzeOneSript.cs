using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PuzzeOneSript : MonoBehaviour
{
    public int PartID;
    public string TagWanted;
    
     public PuzzeCollecterSript PuzzeC;
    // Start is called before the first frame update
    void Start()
    {
        PuzzeC = gameObject.GetComponentInParent<PuzzeCollecterSript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter(Collider Hitinfo){
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
