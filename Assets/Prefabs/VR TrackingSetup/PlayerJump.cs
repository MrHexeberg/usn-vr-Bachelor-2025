using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //fordi vi trenger input key

public class PlayerJump_CharacterController : MonoBehaviour
{
    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groundLayers;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    private void Update()
    {
        bool _isGrounded = IsGrounded();
        if (jumpButton.action.WasPressedThisFrame() && _isGrounded)
        {
            Jump(); //det blir hopp hvis knappen er trykket og spilleren st�r samtidig p� bakken
        }

        movement.y += gravity * Time.deltaTime; //gj�r tyngdekraft
        cc.Move(movement * Time.deltaTime);     //flytter spilleren basert p� movement(bevegelse )
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);  //beregner n�dvendig hastighet til � utf�re "jumpen" til h�yden(jumpheight som er bestemt)
    }

    private bool IsGrounded()  //det her sjekker om spilleren er p� bakken
    {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers);
    }
}
