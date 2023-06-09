using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject ObjectToPool;
    public int startSize;

    [SerializeField] private List<PooledObject> objectPool = new List<PooledObject>();
    [SerializeField] private List<PooledObject> usedPool = new List<PooledObject>();

    private PooledObject tempObject;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Initialize()
    {
        for(int i = 0; i < startSize; i++)
        {
            AddNewObject();
        }
    }

    void AddNewObject()
    {
        tempObject = Instantiate(ObjectToPool, transform).GetComponent<PooledObject>();
        tempObject.gameObject.SetActive(false);
        tempObject.SetObjectPool(this);
        objectPool.Add(tempObject);
    }

    public PooledObject GetPooledObject()
    {
        PooledObject tempObj;

        if(objectPool.Count > 0)
        {
            tempObj = objectPool[0];
            usedPool.Add(tempObj);
            objectPool.RemoveAt(0);
        }
        else
        {
            AddNewObject();
            tempObj = GetPooledObject();
        }

        tempObj.gameObject.SetActive(true);
        tempObj.ResetObject();
        return tempObj;
    }

    public void DestroyPooledObject(PooledObject obj, float time = 0)
    {
        if(time == 0)
        {
            obj.Destroy();
        }
        else
        {
            obj.Destroy(time);
        }
    }

    public void RestoreObject(PooledObject obj)
    {
        Debug.Log("Restored!");
        obj.gameObject.SetActive(false);
        usedPool.Remove(obj);
        objectPool.Add(obj);
    }
}
