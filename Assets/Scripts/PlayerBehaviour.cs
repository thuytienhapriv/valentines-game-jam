using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Animator animator;
    public string state;

    // Start is called before the first frame update
    void Start()
    {
        state = "stir";
        if (state == "stir")
        {
            animator.SetInteger("mode", 0);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            state = "stir love";
            animator.SetInteger("mode", 1);
        }

        /* else if (state == "stir love")
        {
            animator.SetInteger("mode", 1);

        }
*/
    }
}
