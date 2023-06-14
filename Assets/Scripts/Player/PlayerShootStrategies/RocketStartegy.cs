using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStartegy : IShootStrategy
{
    ShootInteractor _interactor;
    Transform shootPoint;

    public RocketStartegy(ShootInteractor interactor)
    {
        Debug.Log("Switched to Rocket strategy");

        _interactor = interactor;
        shootPoint = interactor.GetShootPoint();

        _interactor.gunRenderer.material.color = _interactor.rocketColour;
    }

    public void Shoot()
    {
        PooledObject pooledBullet = _interactor.rocketPool.GetPooledObject();
        pooledBullet.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * _interactor.GetShootVelocity();
        //Destroy(bullet.gameObject, 5.0f);

        _interactor.bulletPool.DestroyPooledObject(pooledBullet, 5.0f);
    }
}
