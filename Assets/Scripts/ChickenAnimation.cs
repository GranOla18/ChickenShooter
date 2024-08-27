using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAnimation : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("Walk", 1);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetFloat("Walk", 2);
            }
        }

        else
        {
            animator.SetFloat("Walk", 0);
        }
    }
}
