using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    [SerializeField] GameObject firstPersonCamera;

    [SerializeField] float movementSpeed = 5.0f;

    InputHandler inputHandler;
    CharacterController characterController;

    float cameraVerticalAngle = 0;

    [SerializeField] Transform groundPoint;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance;



    void Start()
    {
        inputHandler = InputHandler.current;
        characterController = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //movement & rotation
        var movement = (transform.forward * movementSpeed * inputHandler.GetVerticalMoveInput()) + 
                           (transform.right * movementSpeed * inputHandler.GetHorizontalMoveInput());
        characterController.SimpleMove(movement);
        transform.Rotate(Vector3.up * Time.deltaTime * inputHandler.turnSpeed * inputHandler.GetHorizontalLookInput());

        //falling off slopes
        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, groundDistance, groundMask))
        {
            characterController.Move(new Vector3(0, -hit.distance));
            groundDistance = 0.5f;
        }
        else
        {
            groundDistance = 0.1f;
        }


        //camera rotation
        cameraVerticalAngle += Time.deltaTime * inputHandler.turnSpeed * inputHandler.GetVerticalLookInput() * -1.2f;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);
        firstPersonCamera.transform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
    }
}
