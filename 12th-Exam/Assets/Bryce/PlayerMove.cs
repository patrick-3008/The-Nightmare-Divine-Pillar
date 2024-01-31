using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;

public class PlayerMove : MonoBehaviour
{
    public CharacterController bryceController;
    public Camera camera;

    private float gravityY = 0.0f;
    public float mass = 1.0f;

    public Animator bryceAnimation;
    public int lives = 3;

    public Object mummy;

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        else
            UnityEngine.Cursor.lockState = CursorLockMode.None;
    }

    void Start()
    {
        bryceController = GetComponent<CharacterController>();
        bryceAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        float dX = 0.0f;
        float dY = 0.0f;
        dX = Input.GetAxis("Horizontal");
        dY = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(dX, 0, dY);
        movementVector = Quaternion.AngleAxis(camera.transform.eulerAngles.y, Vector3.up) * movementVector;
        movementVector.Normalize();

        gravityY += Physics.gravity.y * mass * Time.deltaTime;

        if (bryceController.isGrounded)
        {
            gravityY = -0.5f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bryceAnimation.SetBool("isJumping", true);
                mummy.GetComponent<MummyController>().alertLevel += 20.0f;
            }
            else
                bryceAnimation.SetBool("isJumping", false);
        }
        
        Vector3 newMoveVector = movementVector;
        newMoveVector.y = gravityY;
        Physics.SyncTransforms();

        if (movementVector != Vector3.zero)
        {
            Quaternion rotationDirection = Quaternion.LookRotation(movementVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationDirection, 360 * Time.deltaTime);
            bryceAnimation.SetBool("isWalking", true);
        }
        else
            bryceAnimation.SetBool("isWalking", false);

        if(lives == 0)
        {
            LostText.changeToLostText();
            bryceAnimation.SetBool("isDead", true);
        }
    }

    private void OnAnimatorMove()
    {
        Vector3 _move = bryceAnimation.deltaPosition;
        _move.y = gravityY;
        bryceController.Move(_move);
    }
}
