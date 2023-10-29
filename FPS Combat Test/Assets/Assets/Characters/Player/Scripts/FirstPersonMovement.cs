using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class FirstPersonMovement : MonoBehaviour
{
    [BoxGroup("References")]
    public CharacterController controller;
    [BoxGroup("References")]
    public InputManager inputManager;

    [BoxGroup("Speeds")]
    public float speed;
    [BoxGroup("Speeds")]
    public float sprintSpeed;
    [BoxGroup("Speeds")]
    public float forwardSpeed;
    [BoxGroup("Speeds")]
    public float backwardsMultiplier;
    [BoxGroup("Speeds")]
    public float sideMultiplier;
    [BoxGroup("Speeds")]
    public float crouchSpeed;
    [BoxGroup("Speeds")]
    public float laySpeed;
    [BoxGroup("Speeds")]
    public float gravity = -9.81f;

    [BoxGroup("Movement")]
    public MoveType moveType;
    [BoxGroup("Movement")]
    public bool sprinting;
    [BoxGroup("Movement")]
    public bool crouching;
    [BoxGroup("Movement")]
    public bool laying;

    [BoxGroup("Jumping")]
    public float jumpHeight;
    [BoxGroup("Jumping")]
    bool isGrounded;
    [BoxGroup("Jumping")]
    public Transform groundCheck;
    [BoxGroup("Jumping")]
    public float groundDistance;
    [BoxGroup("Jumping")]
    public LayerMask groundMask;
    [BoxGroup("Jumping")]
    public bool ig = false;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        speed = forwardSpeed;
        controller = GetComponent<CharacterController>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if(!ig){
                moveType = MoveType.walking;
                ig = true;
            }
        }
        if(inputManager.jump && isGrounded)
        {
            ig = false;
            moveType = MoveType.crouching;
            inputManager.jump = false;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(isGrounded){
            if(inputManager.sprint){
                inputManager.sprint = false;

                if(moveType == MoveType.sprinting){
                    moveType = MoveType.walking;
                }else{
                    moveType = MoveType.sprinting;
                }          
            }
            if(inputManager.crouch){
                inputManager.crouch = false;

                if(moveType == MoveType.crouching){
                    moveType = MoveType.walking;
                }else{
                    moveType = MoveType.crouching;
                }                    
            }

            if(inputManager.lay){
                inputManager.lay = false;

                if(moveType == MoveType.laying){
                    moveType = MoveType.walking;
                }else{
                    moveType = MoveType.laying;
                }             
            }
        }



        float x = inputManager.walk.x;
        float z = inputManager.walk.y;
        Vector3 move = transform.right * x + transform.forward * z;

        switch (moveType)
        {
            case MoveType.walking:            
                speed = forwardSpeed;                
            break;    
            case MoveType.sprinting:
                speed = sprintSpeed;
            break;         
            case MoveType.crouching:
                speed = crouchSpeed;
            break;      
            case MoveType.laying:
                speed = laySpeed;
            break;    
        }
        
        float s = speed;
        if(z < 0){
            speed = s * backwardsMultiplier;
        }else if(x != 0){
            speed = s * sideMultiplier;
        }else{
            switch (moveType)
            {
                case MoveType.walking:            
                    speed = forwardSpeed;                
                break;    
                case MoveType.sprinting:
                    speed = sprintSpeed;
                break;         
                case MoveType.crouching:
                    speed = crouchSpeed;
                break;      
                case MoveType.laying:
                    speed = laySpeed;
                break;    
            }
        }
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

public enum MoveType{
    walking,
    sprinting,
    crouching,
    laying
}