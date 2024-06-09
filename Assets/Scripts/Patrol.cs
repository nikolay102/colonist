using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour
{
    public float distance = 5f;
    public float speed = 2f;
    public float waitTime = 2f;
    public bool isMoving = true;
    private float startPositionX;
    private bool movingRight = true;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    void Start()
    {
        startPositionX = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(MoveObject());
        
    }
    private void Awake()
    {
        animator= GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool("Moving", isMoving);
    }
    IEnumerator MoveObject()
    {
        while (true)
        {
            yield return MoveRight();
            isMoving= false;
            yield return new WaitForSeconds(waitTime);
            FlipSprite();
            isMoving= true;
            yield return MoveLeft();
            isMoving= false;
            yield return new WaitForSeconds(waitTime);
            FlipSprite();
            isMoving= true;
        }
    }

    IEnumerator MoveRight()
    {
        float endPositionX = startPositionX + distance;
        while (transform.position.x < endPositionX)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            yield return null;
        }
    }

    IEnumerator MoveLeft()
    {
        float endPositionX = startPositionX;
        while (transform.position.x > endPositionX)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            yield return null;
        }
    }

    void FlipSprite()
    {

        movingRight = !movingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}