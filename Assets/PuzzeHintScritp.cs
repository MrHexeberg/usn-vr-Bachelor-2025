using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class PuzzeHintScritp : MonoBehaviour
{


    public string TagWanted;
    public string TagWanted2;

    [SerializeField] private GameObject TextFeed;

    public TMP_Text textFrom;
    public TMP_FontAsset textFont;
    public TMP_FontAsset textFontNormal;

    // Start is called before the first frame update
    void Start()
    {
        textFrom = TextFeed.GetComponent<TMP_Text>();
        textFont = textFrom.font;
    }

    // Update is called once per frame
    void Update()
    {
      
    }



    void ShowText(bool show)
    {
        TextFeed.SetActive(show);
    }

    void TranslateText()
    {
        textFrom.font = textFontNormal;

    }


    void OnTriggerEnter(Collider Hitinfo)
    {
        if (Hitinfo.CompareTag(TagWanted))
        {
            ShowText(true);
        }
        else if (Hitinfo.CompareTag(TagWanted2))
        {
            TranslateText();
        }

    }
    void OnTriggerExit(Collider Hitinfo)
    {
        if (Hitinfo.CompareTag(TagWanted))
        {
            ShowText(false);
        }
    }
}