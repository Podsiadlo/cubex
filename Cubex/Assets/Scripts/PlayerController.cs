using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (PlayerController))]
public class PlayerController : MonoBehaviour {
    private CharacterController characterController;
    public float playerSpeed = 10.0f;
    public float mouseSensitivity = 5.0f;
    public float playerJumpSpeed = 5.0f;
    private float verticalRotation = 0;
    private float verticalVelocity = 0;
    private float maximumAngle = 60.0f;
    private int playerHealth = 100;
    private bool isDead = false;

	// Use this for initialization
	void Start () {
        Debug.Log("Init PlayerController");
        disableMouseCursor();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {
        rotateCharacter();
        moveCharacter();
	}

    private void disableMouseCursor()
    {
        Screen.lockCursor = true;
    }

    private void rotateCharacter()
    {
        //X rotation
        float leftRightRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, leftRightRotation, 0);
        
        //Y rotation
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -maximumAngle, maximumAngle);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void moveCharacter()
    {
        float forwardVelocity = Input.GetAxis("Vertical") * playerSpeed;
        float leftRightVelocity = Input.GetAxis("Horizontal") * playerSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if(Input.GetButton("Jump") && characterController.isGrounded)
        {
            verticalVelocity = playerJumpSpeed;
        }

        Vector3 newSpeed = new Vector3(leftRightVelocity, verticalVelocity, forwardVelocity);
        newSpeed = transform.rotation * newSpeed;

        characterController.Move(newSpeed * Time.deltaTime);
    }
    //czy mozliwe jest wykrycie uderzenia przez inny obiekt
    //z poziomu CharacterControllera?
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log("Player's collision with: " + hit.gameObject.name);
    }

    public void removeHealth(int delta)
    {
        playerHealth -= delta;

        Debug.Log("Current health: " + playerHealth);

        if (playerHealth<=0 && !isDead)
        {
            isDead = true;
            Debug.Log("Player is dying.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

}
