using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public CharacterController controller;
    Vector3 moveVector;
    public float currentSpeed;
    public float moveSpeed = 15f;
    public float runSpeed = 35f;
    public float gravity = -100f;
    public float jumpForce = 20f;
    public bool isJumping = false;
    Vector3 velocity;

    void Update() {
        Run();
        Move();
    }

    void Move() {
        if(IsGrounded() && velocity.y < 0) {
            velocity.y = 0f;
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        moveVector = transform.right * inputX + transform.forward * inputZ;
        controller.Move(moveVector * currentSpeed * Time.deltaTime);

        // Jump
        Jump();
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Jump() {
        if(Input.GetButtonDown("Jump") && IsGrounded()) {
            StartCoroutine("Jumping");
        }
    }

    IEnumerator Jumping() {    
		isJumping = true;
		velocity.y = jumpForce;
		yield return new WaitForSeconds(1);
		isJumping = false;
	}
    private bool IsGrounded() {
		Ray groundRay = new Ray(new Vector3( controller.bounds.center.x, (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f, controller.bounds.center.z), Vector3.down );
		return (Physics.Raycast(groundRay, 0.2f + 0.1f));
	}

    private void Run() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            currentSpeed = runSpeed;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            currentSpeed = moveSpeed;
        }
    }
}
