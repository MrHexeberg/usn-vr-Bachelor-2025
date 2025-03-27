using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSkript : MonoBehaviour
{

    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator != null)
        {
            if(Input.GetKeyDown(KeyCode.O))
            {
                mAnimator.SetTrigger("TgPageForward");
            }
            if(Input.GetKeyDown(KeyCode.P))
            {
                mAnimator.SetTrigger("TgPageBack");
            }
        }
    }
}
