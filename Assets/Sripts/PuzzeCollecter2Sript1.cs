using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PuzzeShowhint: PuzzeCollecterSript
{
 
    [SerializeField] private GameObject TextFeed;
 

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PuzzelPart(int PartID, bool State)
    {
        Parts[PartID] = State;
        
        for (int i = 0; i < Parts.Length; i++)
        {
            if (Parts[i] == false)
            {
                ShowText(false);
                break;
            }
            else if (Parts[i] == true && i == Parts.Length - 1)
            {
                ShowText(true);
            }

        }
    }


    void ShowText(bool show)
    {
        TextFeed.SetActive(show);
    }

    void TranslateText()
    {


    }

}