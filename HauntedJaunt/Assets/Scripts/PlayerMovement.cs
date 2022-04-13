using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity; 

    public float turnSpeed = 20;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Called before physics system soles any collisions and other interactions that have happened (50 times every second)
    void FixedUpdate()
    {
        // Retrieve our input on our Horizontal and Vertical axis
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Store them into a movement Vector then normalize it so that we do not move faster on diagonal movement
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        // Determine if player is idle or walking, ie movement vertical and horizontal are approx. 0f
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        
        // If Lemon is walking play audio, else do not
        if(isWalking)
        {
            if(!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        } else {
            m_AudioSource.Stop();
        }

        // Sets animation behavior depending on current movement of our player
        m_Animator.SetBool("IsWalking", isWalking);

        // Code to determine the rotation of our player character for the desired movement direction (face the way you walk)
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    // Moves our animated player character
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
