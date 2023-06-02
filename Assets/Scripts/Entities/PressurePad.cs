using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask pickupLayer;

    public UnityEvent OnCubePlaced;
    public UnityEvent OnCubeRemoved;


    private void OnCollisionEnter(Collision collision)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius, pickupLayer);
        Debug.Log(hitColliders.Length);

        foreach(var collider in hitColliders)
        {
            if(collider.CompareTag("PickCube"))
            {
                OnCubePlaced?.Invoke();
                break;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("PickCube"))
        {
            OnCubeRemoved?.Invoke();
        }
    }
}
