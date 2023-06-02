using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractor : Interactor
{
    [Header("Pick and Drop")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private float pickupDistance;
    [SerializeField] private Transform attachTransform;

    private bool isPicked = false;
    private IPickable pickable;
    private RaycastHit raycastHit;

    public override void Interact()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out raycastHit, pickupDistance, pickupLayer))
        {
            if (playerInput.activatePressed && !isPicked)
            {
                pickable = raycastHit.transform.GetComponent<IPickable>();

                if (pickable == null)
                {
                    return;
                }

                pickable.OnPicked(attachTransform);
                isPicked = true;
                return;
            }
        }

        if (playerInput.activatePressed && isPicked && pickable != null)
        {
            pickable.OnDropped();
            isPicked = false;
        }
    }
}
