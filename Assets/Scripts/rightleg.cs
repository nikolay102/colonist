using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rightleg : MonoBehaviour



{
    [SerializeField] private Transform williamTransform;
    [SerializeField] private Animator animator;
    public static rightleg Instance;
    private bool istriggered;
    private Human human;


    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("rightlegs", false);
        human= williamTransform.GetComponent<Human>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLegs();
    }
    private void Awake()
    {


    }
    private void FixedUpdate()
    {

    }
    private void CheckLegs()
    {
        animator.SetBool("rightleg", istriggered);
    }
    private IEnumerator moving()
    {
        if (human.Head.headON == false)
        {
        yield return new WaitForSeconds(0.5f);
        istriggered = false;
        yield return null;
        williamTransform.transform.position = new Vector2(williamTransform.transform.position.x + 0.8f, williamTransform.transform.position.y + 1f);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (human.Head.headON == false)
        {
        istriggered = true;
        animator.SetBool("rightlegs", true);
        StartCoroutine(moving());
        Debug.Log("���� ������");

        }
            

    }

}
