using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Animator animator;
    public string state;
    public int stirTime;

    // Start is called before the first frame update
    void Start()
    {
        /*state = "stir";
        if (state == "stir")
        {
            animator.SetInteger("mode", 0);
        }*/
    }

    
    public void Idle()
    {
        animator.SetInteger("mode", 10);
    }


    public void Stir()
    {
        animator.SetInteger("mode", 0);
    }

    public void LoveWin()
    {
        animator.SetInteger("mode", 1);
    }

    public void LoveLose()
    {
        animator.SetInteger("mode", 2);
    }

    public void PlatWin()
    {
        animator.SetInteger ("mode", 5);
        Debug.Log("plat win");
    }

    public void PlatLose()
    {
        animator.SetInteger("mode", 0);
        animator.SetInteger("mode", 6);
    }

    public void ParentWin()
    {
        animator.SetInteger("mode", 3);
    }

    public void ParentLose()
    {
        animator.SetInteger("mode", 4);
    }


}
