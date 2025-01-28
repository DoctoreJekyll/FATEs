using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float xValue;
    private float yValue;
    
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private ButtonAxis buttonAxis;

    [SerializeField] 
    private bool isOnKeyBoard;

    [SerializeField] private AudioClip audioClip;
    
    private Animator playerAnimations;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        Flip();
        MoveAnimation();
    }

    private void FixedUpdate()
    {
        if (!isOnKeyBoard)
        {
            Move();
        }
        else
        {
            rb2d.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
            if (rb2d.linearVelocity.x != 0)
            {
                transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal") , transform.localScale.y, transform.localScale.z);
            }
            
        }
        
    }

    private void Move()
    {
        rb2d.linearVelocity = new Vector2(GetXValue() * movementSpeed, GetYValue() * movementSpeed);
    }

    private void MoveAnimation()
    {
        if (GetXValue() != 0 || GetYValue() != 0)
        {
            playerAnimations.SetBool("Moving", true);
        }
        else
        {
            playerAnimations.SetBool("Moving", false);
        }
    }

    private float GetXValue()
    {
        xValue = buttonAxis.GetX();
        return xValue;
    }

    private float GetYValue()
    {
        yValue = buttonAxis.GetY();
        return yValue;
    }

    private void Flip()
    {
        if (GetXValue() != 0)
        {
            transform.localScale = new Vector3(GetXValue(), transform.localScale.y, transform.localScale.z);
        }
    }

    public void StepSoundMoveOriginal()
    {
        audioSource.PlayOneShot(audioClip);
    }
    
}
