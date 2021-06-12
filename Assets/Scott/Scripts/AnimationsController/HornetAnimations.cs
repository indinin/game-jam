using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void FlyAnim()
    {
        animator.SetBool("flying", true);
        Debug.Log("Moving - Hornet");
    }

    public void AttackAnim()
    {
        animator.SetTrigger("attack");
        Debug.Log("Attacking - Hornet");
    }
}
