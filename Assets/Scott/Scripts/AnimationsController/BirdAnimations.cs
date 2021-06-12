using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void FlyAnim()
    {
        animator.SetBool("flying", true);
        Debug.Log("Moving - Bird");
    }
}
