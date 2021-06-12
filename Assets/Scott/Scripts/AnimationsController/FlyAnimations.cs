using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void FlyAnim()
    {
        animator.SetBool("flying", true);
        Debug.Log("Moving - Fly");
    }

    public void CaughtAnim()
    {
        animator.SetBool("caught", true);
        animator.SetBool("flying", false);
        Debug.Log("Caught - Fly");
    }

    public void UnstuckAnim()
    {
        animator.SetBool("caught", false);
        Debug.Log("Caught - Fly");
    }
}
