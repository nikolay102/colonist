using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CliffLogic : MonoBehaviour
    {
        [SerializeField] private Transform williamTransform;
        [SerializeField] private Animator animator;
        private Human human;
        private bool istriggered;

        void Start()
        {
            animator.SetBool("legs", false);
            human = williamTransform.GetComponent<Human>();
        }

        private IEnumerator CliffingCoroutine(bool isLeft)
        {
            yield return new WaitForSeconds(0.4f);
            istriggered = false;
            yield return null;
            williamTransform.transform.position = new Vector2(
                williamTransform.transform.position.x + (isLeft ? -0.8f : 0.8f),
                williamTransform.transform.position.y + 1f);
            animator.SetBool("legs", false);
            human.Feet.IsGrounded = true;
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (human.Head.headON) return;

            var left = collider2D.transform.position.x - transform.position.x < 0;

            animator.SetBool("legs", true);
            StartCoroutine(CliffingCoroutine(left));
        }
    }
}