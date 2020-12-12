using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    public bool isMoving;
    private Vector2 input;
    private Animator animator;

    public GameObject messagePannel;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (Input.GetKey("space"))
            {
                moveSpeed = 3000;
            }
            else
            {
                moveSpeed = 1000;
            }
            
            
            
            //Remove diagonal movement
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (isWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);
        
        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    public void UpdateGender(Boolean g)
    {
        animator.SetBool("gender",g);
    }
    
    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat(("moveX")), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;
        
        var collider = Physics2D.OverlapCircle(interactPos, 1f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        
        messagePannel.GetComponentInChildren<Text>().enabled = false;
        messagePannel.GetComponent<Image>().enabled = false;
        
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        
        isMoving = false;
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.5f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }

        return true;
    }
}
