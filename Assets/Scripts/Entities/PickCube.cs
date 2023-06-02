using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCube : MonoBehaviour, IPickable
{
    Rigidbody cubeRB;


    void Start()
    {
        cubeRB = GetComponent<Rigidbody>();
    }

    public void OnDropped()
    {
        cubeRB.isKinematic = false;
        cubeRB.useGravity = true;
        transform.SetParent(null);
    }

    public void OnPicked(Transform attachTransform)
    {
        transform.position = attachTransform.position;
        transform.rotation = attachTransform.rotation;
        transform.SetParent(attachTransform);

        cubeRB.isKinematic = true;
        cubeRB.useGravity = false;
    }
}
