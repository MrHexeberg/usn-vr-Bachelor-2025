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

    }
    void PageForward() {
    mAnimator.SetTrigger("TgPageForward");
}

    void PageBack() {
        mAnimator.SetTrigger("TgPageBack");
    }

 public void  PageSwith (){

     if (mAnimator != null){
        if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("page forward")){
            PageBack();
        }
        else{
            PageForward();
        }
     }
 }




}



