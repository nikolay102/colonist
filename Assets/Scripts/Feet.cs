using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public bool IsGrounded => isGround;

    private bool isGround;

    private int CollisionsCount;

    private void Update()
    {
        Debug.Log(CollisionsCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        CollisionsCount += 1;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionsCount -= 1;
        if(CollisionsCount == 0)
            isGround = false;
    }
}
