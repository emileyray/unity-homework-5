using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private float velocityZ = 0;
    private float velocityX = 0;

    public float acceleration = 1f;
    public float deceleration = 1f;
    
    private float vertical;
    private float horizontal;

    private Vector2 turn;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * 2f;
        transform.rotation = Quaternion.Euler(0, turn.x, 0);

        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);

        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        float forwardMaxSpeed = leftPressed || rightPressed ? 1f : 2f;
        float sideMaxSpeed = backwardPressed ? 1f : 1.5f;

        handleForward(forwardPressed, forwardMaxSpeed);
        handleBackward(backwardPressed, 1f);
        handleRight(rightPressed, sideMaxSpeed);
        handleLeft(leftPressed, sideMaxSpeed);

        handleStop(forwardPressed, rightPressed, backwardPressed, leftPressed);



        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);

    }

    void handleStop(bool forwardPressed, bool rightPressed, bool backwardPressed, bool leftPressed)
    {
        if (!backwardPressed && !forwardPressed)
        {
            if (velocityZ > 0)
            {
                velocityZ -= Time.deltaTime * deceleration;
                if (velocityZ <= 0)
                {
                    velocityZ = 0.0f;
                }
            }

            if (velocityZ < 0)
            {
                velocityZ += Time.deltaTime * deceleration;
                if (velocityZ >= 0)
                {
                    velocityZ = 0.0f;
                }
            }
        }
        
        if (!leftPressed && !rightPressed)
        {
            if (velocityX > 0)
            {
                velocityX -= Time.deltaTime * deceleration;
                if (velocityX <= 0)
                {
                    velocityX = 0.0f;
                }
            }

            if (velocityX < 0)
            {
                velocityX += Time.deltaTime * deceleration;
                if (velocityX >= 0)
                {
                    velocityX = 0.0f;
                }
            }
        }
    }
    
    void handleForward(bool forwardPressed, float maxSpeed)
    {
        if (forwardPressed && velocityZ > maxSpeed)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if (velocityZ < maxSpeed)
            {
                velocityZ = maxSpeed;
            }
        }
        
        if (forwardPressed && velocityZ <= maxSpeed)
        {
            velocityZ += Time.deltaTime * acceleration;
            if (velocityZ > maxSpeed)
            {
                velocityZ = maxSpeed;
            }
        }
    }

    void handleBackward(bool backwardPressed, float maxSpeed)
    {
        if (backwardPressed && velocityZ >= -maxSpeed)
        {
            velocityZ -= Time.deltaTime * acceleration;
            if (velocityZ < -maxSpeed)
            {
                velocityZ = -maxSpeed;
            }
        }
    }

    void handleRight(bool rightPressed, float maxSpeed)
    {
        if (rightPressed && velocityX > maxSpeed)
        {
            velocityX -= Time.deltaTime * deceleration;
            if (velocityX < maxSpeed)
            {
                velocityX = maxSpeed;
            }
        }
        
        if (rightPressed && velocityX <= maxSpeed)
        {
            velocityX += Time.deltaTime * acceleration;
            if (velocityX > maxSpeed)
            {
                velocityX = maxSpeed;
            }
        }
    }
    
    void handleLeft(bool leftPressed, float maxSpeed)
    {
        if (leftPressed && velocityX < -maxSpeed)
        {
            velocityX += Time.deltaTime * deceleration;
            if (velocityX > -maxSpeed)
            {
                velocityX = -maxSpeed;
            }
        }
        
        if (leftPressed && velocityX >= -maxSpeed)
        {
            velocityX -= Time.deltaTime * acceleration;
            if (velocityX < -maxSpeed)
            {
                velocityX = -maxSpeed;
            }
        }
    }

    public float getVelocityX()
    {
        return velocityX;
    }
    
    public float getVelocityZ()
    {
        return velocityZ;
    }
}
