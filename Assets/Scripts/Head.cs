using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour

{
    [SerializeField] private Animator animator;
    private bool istriggered;
    public bool headON;

    // Start is called before the first frame update
    void Start()
    {
        headON = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHead();
    }
    void CheckHead()
    {
        animator.SetBool("head", istriggered);
    }
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        {
            istriggered = true;
            animator.SetBool("head", true);
            Debug.Log("������ ������");
            headON= true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        istriggered= false;
        animator.SetBool("head", false);
        Debug.Log("��� ��������");
        headON= false;
    }
}
