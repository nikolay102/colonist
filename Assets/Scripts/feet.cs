using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feet : MonoBehaviour
{
    public bool IsGrounded=>isGrounded;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded=true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded=false;
    }
}
