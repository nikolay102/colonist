using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour

{
    [SerializeField] private Animator animator;
    
    public bool headON;

    // Start is called before the first frame update
    void Start()
    {
        headON = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        {
           
            headON= true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        headON= false;
    }
}
