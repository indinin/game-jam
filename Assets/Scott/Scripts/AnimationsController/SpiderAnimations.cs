using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void MovingLeftAnim()
    {
        animator.SetBool("movingLeft", true);
        animator.SetBool("movingRight", false);
        Debug.Log("Moving Left - Spider");
    }

    public void MovingRightAnim()
    {
        animator.SetBool("movingLeft", false);
        animator.SetBool("movingRight", true);
        Debug.Log("Moving Right - Spider");
    }

    public void StopMovingAnim()
    {
        animator.SetBool("movingLeft", false);
        animator.SetBool("movingRight", false);
        Debug.Log("Stopped - Spider");
    }

    public void JumpAnim()
    {
        animator.SetTrigger("jump");
        Debug.Log("Jumping - Spider");
    }

    public void DeathAnim()
    {
        animator.SetTrigger("dead");
        Debug.Log("SPLAT! - Spider");
    }
}
