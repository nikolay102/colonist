using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public bool IsGrounded => isGround;

    private bool isGround;

    private int сollisionsCount;

    private void Update()
    {
        Debug.Log(сollisionsCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        сollisionsCount += 1;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        сollisionsCount -= 1;
        if(сollisionsCount == 0)
            isGround = false;
    }
}
