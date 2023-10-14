using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler current;
    
    public float turnSpeed = 300;

    private void Awake()
    {
        current = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) ChargeStart();
        if (Input.GetButtonUp("Fire1")) ChargeRelease();
    }

    public float GetVerticalMoveInput()
    {
        return Input.GetAxis("Vertical");
    }
    public float GetHorizontalMoveInput()
    {
        return Input.GetAxis("Horizontal");
    }
    public float GetVerticalLookInput()
    {
        return Input.GetAxisRaw("Mouse Y");
    }
    public float GetHorizontalLookInput()
    {
        return Input.GetAxisRaw("Mouse X");
    }

    public event Action onChargeStart;
    public void ChargeStart()
    {
        if (onChargeStart != null) onChargeStart();
    }

    public event Action onChargeRelease;
    public void ChargeRelease()
    {
        if (onChargeRelease != null) onChargeRelease();
    }
}
