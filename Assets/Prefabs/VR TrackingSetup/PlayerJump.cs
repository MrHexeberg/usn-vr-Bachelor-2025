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
            Jump(); //det blir hopp hvis knappen er trykket og spilleren står samtidig på bakken
        }

        movement.y += gravity * Time.deltaTime; //gjør tyngdekraft
        cc.Move(movement * Time.deltaTime);     //flytter spilleren basert på movement(bevegelse )
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);  //beregner nødvendig hastighet til å utføre "jumpen" til høyden(jumpheight som er bestemt)
    }

    private bool IsGrounded()  //det her sjekker om spilleren er på bakken
    {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers);
    }
}
