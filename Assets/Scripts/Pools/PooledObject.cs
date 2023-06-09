using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PooledObject : MonoBehaviour
{
    [SerializeField] private UnityEvent OnReset;

    ObjectPool associatedPool;

    private float timer;
    private float destroyTime = 0;
    private bool setToDestroy = false;

    public void SetObjectPool(ObjectPool pool)
    {
        associatedPool = pool;
        timer = 0;
        destroyTime = 0;
        setToDestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(setToDestroy)
        {
            timer += Time.deltaTime;

            if(timer >= destroyTime)
            {
                setToDestroy = false;
                timer = 0;
                Destroy();
            }
        }
    }

    public void ResetObject()
    {
        OnReset?.Invoke();
    }

    public void Destroy()
    {
        if(associatedPool != null)
        {
            associatedPool.RestoreObject(this);
        }
    }

    public void Destroy(float time)
    {
        setToDestroy = true;
        destroyTime = time;
    }
}
