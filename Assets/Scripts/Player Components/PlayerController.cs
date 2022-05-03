using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject firstPersonCamera;
    [SerializeField] BowController bow;

    [SerializeField] float movementSpeed = 5.0f;

    InputHandler inputHandler;
    CharacterController characterController;

    float cameraVerticalAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = InputHandler.current;
        characterController = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //movement & rotation
        Vector3 movement = (transform.forward * movementSpeed * inputHandler.GetVerticalMoveInput()) + 
                           (transform.right * movementSpeed * inputHandler.GetHorizontalMoveInput());
        characterController.SimpleMove(movement);
        transform.Rotate(Vector3.up * Time.deltaTime * inputHandler.turnSpeed * inputHandler.GetHorizontalLookInput());

        //camera rotation
        cameraVerticalAngle += Time.deltaTime * inputHandler.turnSpeed * inputHandler.GetVerticalLookInput() * -1.2f;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);
        firstPersonCamera.transform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
    }
}
