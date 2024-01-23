using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private Feet feet;
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 3;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Head head;

    private bool getReady;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public Feet Feet => feet;


    public Head Head
    {
        get { return head; }
    }

    public static Human Instance { get; set; }
    private Animator animator;

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            if (lives == 0)
            {
                animator.SetTrigger("death");
            }
        }
    }


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()

    {
        if (Input.GetButton("Horizontal"))
            Run();
        else
            animator.SetBool("IsRunnung", false);
        if (feet.IsGrounded && Input.GetKeyDown(KeyCode.Space))
            Jump();
        animator.SetBool("onground", feet.IsGrounded);
        GetReady();
    }

    public void GetDamage()
    {
        lives -= 1;
    }

    private void GetReady()
    {
        if (Input.GetKeyDown("q"))
        {
            Debug.Log("��");
            getReady = !getReady;
            animator.SetBool("getready", getReady);
        }
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
        animator.SetBool("IsRunnung", true);
    }

    private void FixedUpdate()
    {
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        animator.SetBool("IsRunnung", false);
    }


    private void Death()
    {
        Destroy(gameObject);
    }
}