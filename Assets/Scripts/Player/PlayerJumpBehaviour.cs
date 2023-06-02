using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementBehaviour))]
public class PlayerJumpBehaviour : Interactor
{
    [Header("Jump")]
    [SerializeField] private float jumpVelocity;

    private PlayerMovementBehaviour moveBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        moveBehaviour = GetComponent<PlayerMovementBehaviour>();
    }

    public override void Interact()
    {
        if(playerInput.jumpPressed && moveBehaviour.isGrounded)
        {
            moveBehaviour.SetYVelocity(jumpVelocity);
        }
    }
}
