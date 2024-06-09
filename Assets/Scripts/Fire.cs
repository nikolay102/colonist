using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private bool isFacingRight = true;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal < 0 && isFacingRight)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}