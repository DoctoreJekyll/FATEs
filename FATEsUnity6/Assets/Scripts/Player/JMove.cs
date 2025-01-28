using System;
using UnityEngine;

public class JMove : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;

    private Rigidbody2D rb2d;

    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private AudioClip stepSound;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Flip();
        
        Debug.Log(joystick.Direction.x);
    }


    private void FixedUpdate()
    {
        if (joystick.Direction.y != 0 || joystick.Direction.x != 0)
        {
            rb2d.linearVelocity = new Vector2(joystick.Direction.x * speed, joystick.Direction.y * speed);
            animator.SetBool("Moving", true);
        }
        else
        {
            rb2d.linearVelocity = Vector2.zero;
            animator.SetBool("Moving", false);
        }
    }
    
    private void Flip()
    {
        if (joystick.Direction.x != 0)
        {
            transform.localScale = new Vector3(joystick.Direction.x , transform.localScale.y, transform.localScale.z);
        }
    }
    
    public void StepSound()
    {
        audioSource.PlayOneShot(stepSound);
    }
}
