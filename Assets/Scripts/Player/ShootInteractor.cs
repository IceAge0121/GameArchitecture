using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [SerializeField] private Input inputType;

    [Header("Player Shoot")]
    //[SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private ObjectPool bulletPool;
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

        PooledObject pooledBullet = bulletPool.GetPooledObject();
        pooledBullet.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * finalShootVelocity;
        //Destroy(bullet.gameObject, 5.0f);

        bulletPool.DestroyPooledObject(pooledBullet, 5.0f);
    }
}
