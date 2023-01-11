using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    public bool isEmpty = true;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!isEmpty)
        {
            animator.SetBool("Empty", false);
            StartCoroutine(DisableHighlight());
        }
    }

    IEnumerator DisableHighlight()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
