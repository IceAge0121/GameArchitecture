using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /*[SerializeField] private MeshRenderer doorRenderer;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material detectedDoorMaterial;*/
    
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private const float waitTime = 1.0f;

    private bool isLocked = true;
    private float timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(!isLocked && other.CompareTag("Player"))
        {
            timer = 0;
            //doorRenderer.material = detectedDoorMaterial;
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
            //doorAnimator.SetBool("Door", true);
            OpenDoor(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //doorAnimator.SetBool("Door", false);
        OpenDoor(false);
        //doorRenderer.material = defaultMaterial;
    }

    public void LockDoor()
    {
        isLocked = true;
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }

    public void OpenDoor(bool state)
    {
        if(!isLocked)
        {
            doorAnimator.SetBool("Door", state);
        }
    }
}
