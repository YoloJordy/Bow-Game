using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public float turnSpeed = 300;

    [SerializeField] float chargeTime = 2.5f;
    float chargeMax = 1f;
                           
    float chargeAmount = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && chargeAmount < chargeMax) {chargeAmount += chargeMax / chargeTime * Time.deltaTime; Debug.Log(chargeAmount); }
        else if (GetChargeRelease()) chargeAmount = 0;
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
    public float GetChargeAmount()
    {
        return chargeAmount;
    }
    public bool GetChargeRelease()
    {
        return !Input.GetButton("Fire1") && GetChargeAmount() > 0;
    }
}
