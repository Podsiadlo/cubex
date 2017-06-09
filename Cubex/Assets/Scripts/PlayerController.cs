using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (PlayerController))]
public class PlayerController : MonoBehaviour {
    private CharacterController characterController;
    private AudioSource audioSource;
    private Rigidbody ridgitBody;

    //PUBLIC VARIABLES
    public float minVerticalPosition = -55.0f;
    public float fallingSoundPosition = -38.0f;
    public float playerSpeed = 10.0f;
    public float mouseSensitivity = 5.0f;
    public float playerJumpSpeed = 5.0f;
    public AudioClip jumpSound;
    public AudioClip fallingSound;

    private float verticalRotation = 0;
    private float verticalVelocity = 0;
    private float maximumAngle = 60.0f;

    public void Move(Vector3 movementVector, float rotation)
    {
        //characterController.Move(movementVector);
        transform.Rotate(0, rotation, 0);
        transform.Translate(movementVector);
    }

    private int playerHealth = 100;
    private bool isDead = false;
    private int deathCounter = 0;
    private AudioClip[] footsteps = new AudioClip[0];
    private bool isPlayerFalling = false;

    void Start () {
        Debug.Log("Init PlayerController");

        disableMouseCursor();
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        ridgitBody = GetComponent<Rigidbody>();
        footsteps = Resources.LoadAll<AudioClip>("Audio/Player");
    }

    void Update () {
        checkIfPlayerFelt();
        rotateCharacter();
        moveCharacter();
	}

    private void disableMouseCursor()
    {
        //Disable cursor
        Cursor.visible = false;
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
            audioSource.PlayOneShot(jumpSound, 0.3f);
        }

        Vector3 newSpeed = new Vector3(leftRightVelocity, verticalVelocity, forwardVelocity);
        newSpeed = transform.rotation * newSpeed;

        characterController.Move(newSpeed * Time.deltaTime);
    }

    private bool hasCharacterMoved()
    {
        return ridgitBody.velocity.magnitude > 0;
    }

    public void playFootstep() {

    }

    private void checkIfPlayerFelt()
    {
        Vector3 playerPosition = this.transform.position;

        if (playerPosition.y < fallingSoundPosition && !isPlayerFalling)
        {
            Debug.Log("Player is falling");
            audioSource.PlayOneShot(fallingSound);
            isPlayerFalling = true;
        }
        if (playerPosition.y < minVerticalPosition)
        {
            Debug.Log("Player current vertical position is " + playerPosition.y);
            kill();
        }
    }

    public void kill()
    {
        isDead = true;
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

}
