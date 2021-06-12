using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void MovingAnim()
    {
        animator.SetBool("moving", true);
        Debug.Log("Moving");
    }

    public void StopMovingAnim()
    {
        animator.SetBool("moving", false);
        Debug.Log("Not Moving");
    }

    public void JumpAnim()
    {
        animator.SetTrigger("jump");
        Debug.Log("Jumping");
    }

    public void DeathAnim()
    {
        animator.SetTrigger("dead");
        Debug.Log("SPLAT!");
    }
}
