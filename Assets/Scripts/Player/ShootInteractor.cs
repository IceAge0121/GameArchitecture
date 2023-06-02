using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [SerializeField] private Input inputType;

    [Header("Player Shoot")]
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce;
    [SerializeField] private PlayerMovementBehaviour moveBehaviour;

    private float finalShootVelocity;
    public enum Input
    {
        Primary,
        Secondary
    }

    public override void Interact()
    {
        if(inputType == Input.Primary && playerInput.primaryShootPressed || inputType == Input.Secondary && playerInput.secondaryShootPressed)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        finalShootVelocity = moveBehaviour.GetForwardSpeed() + shootForce;

        Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.velocity = shootPoint.forward * finalShootVelocity;
        Destroy(bullet.gameObject, 5.0f);
    }
}
