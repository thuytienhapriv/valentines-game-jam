using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Animator animator;
    public string state;
    public int stirTime;

    public void Update()
    {
        if (animator.GetInteger("mode") != 10)
        {
            gameObject.transform.position = new Vector3(22.9f, -1.88f, 0);
        } else
        {
            gameObject.transform.position = new Vector3(20.9f, -1.88f, 0);

        }
    }

    public void Idle()
    {
        animator.SetInteger("mode", 10);
    }


    public void Stir()
    {
        animator.SetInteger("mode", 0);
    }
    
    public void PlatWin()
    {
        animator.SetInteger("mode", 5);
    }

    public void PlatLose()
    {
        animator.SetInteger("mode", 6);
    }

    public void LoveWin()
    {
        animator.SetInteger("mode", 1);
    }

    public void LoveLose()
    {
        animator.SetInteger("mode", 2);
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
