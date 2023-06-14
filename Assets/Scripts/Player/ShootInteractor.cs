using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [SerializeField] private Input inputType;

    [Header("Gun")]
    public MeshRenderer gunRenderer;
    public Color bulletColour;
    public Color rocketColour;

    [Header("Player Shoot")]
    public ObjectPool bulletPool;
    public ObjectPool rocketPool;

    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce;
    [SerializeField] private PlayerMovementBehaviour moveBehaviour;

    private float finalShootVelocity;
    private IShootStrategy currentShootStrategy;

    /*public enum Input
    {
        Primary,
        Secondary
    }*/

    public override void Interact()
    {
        if(currentShootStrategy == null)
        {
            currentShootStrategy = new BulletStrategy(this);
        }

        //Change strategy
        if(playerInput.weapon1Pressed)
        {
            currentShootStrategy = new BulletStrategy(this);
        }

        if(playerInput.weapon2Pressed)
        {
            currentShootStrategy = new RocketStartegy(this);
        }

        if(playerInput.primaryShootPressed && currentShootStrategy != null)
        {
            currentShootStrategy.Shoot();
        }
    }

    void Shoot()
    {
        

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

    public float GetShootVelocity()
    {
        finalShootVelocity = moveBehaviour.GetForwardSpeed() + shootForce;
        return finalShootVelocity;
    }

    public Transform GetShootPoint()
    {
        return shootPoint;
    }
}
