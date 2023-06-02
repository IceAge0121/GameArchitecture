using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private MeshRenderer doorRenderer;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material detectedDoorMaterial;
    [SerializeField] private Animator doorAnimator;

    private bool isLocked = true;
    private float timer = 0;

    private const float waitTime = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(!isLocked && other.CompareTag("Player"))
        {
            timer = 0;
            doorRenderer.material = detectedDoorMaterial;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(isLocked)
        {
            return;
        }

        if(!other.CompareTag("Player"))
        {
            return;
        }

        timer += Time.deltaTime;

        if(timer >= waitTime)
        {
            timer = waitTime;
            doorAnimator.SetBool("Door", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetBool("Door", false);
        doorRenderer.material = defaultMaterial;
    }

    public void LockDoor()
    {
        isLocked = true;
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }
}
