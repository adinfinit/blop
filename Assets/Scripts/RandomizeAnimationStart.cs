using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAnimationStart: MonoBehaviour
{
    void Start()
    {
        var animator = GetComponent<Animator>();
        animator.Play(0, -1, Random.Range(0.0f, 1.0f));
    }
}
