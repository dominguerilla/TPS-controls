using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TPPlatformerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    // TODO: This immediately moves player to this height. It should move at a speed of jumpSpeed * Time.deltaTime until it hits the start_point_of_jump + jumpHeight, and should then fall down as this does.
    [SerializeField]
    private float jumpHeight = 8.0f;

    [SerializeField]
    private float jumpSpeed = 8.0f;

    [SerializeField]
    private float gravity = 5.0f;

    private CharacterController controller;
    private bool isJumping = false;
    private Vector3 jumpStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
    }

    void CheckForInput(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float vertSpeed = 0f;
        
        if(controller.isGrounded) {
            if (Input.GetKeyDown(KeyCode.Space))  {
                isJumping = true;
                jumpStartPosition = transform.position;
            }
        }

        if (isJumping) {
            if(transform.position.y >= jumpStartPosition.y + jumpHeight) {
                isJumping = false;
            }else {
                vertSpeed += jumpSpeed * Time.deltaTime;
            }
        }else {
            vertSpeed -= gravity * Time.deltaTime;
        }
        
        Vector3 moveDirectionForward = transform.forward * vertical;
        Vector3 moveDirectionSide = transform.right * horizontal;

        Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
        Vector3 distance = (direction * moveSpeed) * Time.deltaTime; 
        distance += new Vector3(0, vertSpeed, 0);
        controller.Move(distance);
    }
}
