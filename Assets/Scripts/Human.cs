using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private Feet feet;
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 3;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Head head;

    public bool IsWithWeapon { get; set; }
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public Feet Feet => feet;

    
    public bool Freezed { get; set; }
    

    public Head Head
    {
        get { return head; }
    }
    
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
        animator.SetBool("Active", true);
    }

    private void Update()

    {
        if (Freezed) 
            return;
        if (Input.GetButton("Horizontal"))
            Run();
        else
            animator.SetBool("IsRunning", false);
        
        if (feet.IsGrounded && Input.GetKeyDown(KeyCode.Space))
            Jump();
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
            IsWithWeapon = !IsWithWeapon;
            animator.SetTrigger(IsWithWeapon ? "TakeWeapon" : "HideWeapon");
            animator.SetBool("ReadyOrNot", IsWithWeapon);
        }
        if (Input.GetKeyDown("e"))
        {
            animator.SetTrigger("Cliff");
        }
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
        animator.SetBool("IsRunning", true);
    }

    private void FixedUpdate()
    {
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        animator.SetTrigger("Jump");
    }


    private void Death()
    {
        Destroy(gameObject);
    }
}