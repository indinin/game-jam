using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void MovingLeftAnim()
    {
        animator.SetBool("moving", true);
        Debug.Log("Moving - Spider");
    }

    public void StopMovingAnim()
    {
        animator.SetBool("moving", false);
        Debug.Log("Stopped - Spider");
    }

    public void JumpAnim()
    {
        animator.SetTrigger("jump");
        Debug.Log("Jumping - Spider");
    }

    public void EatAnim()
    {
        animator.SetTrigger("eat");
        Debug.Log("Eating - Spider");
    }

    public void DeathAnim()
    {
        animator.SetTrigger("dead");
        Debug.Log("SPLAT! - Spider");
    }
}
