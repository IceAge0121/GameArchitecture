using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private GameObject objectToBuild;
    [SerializeField] private Transform buildPoint;

    public void Build()
    {
        Instantiate(objectToBuild, buildPoint.position, buildPoint.rotation);
        Destroy(gameObject);
    }
}
