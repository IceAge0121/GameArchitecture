using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteractor : Interactor
{
    [Header("Interact")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask buttonLayer;
    [SerializeField] private float interactionDistance;

    private RaycastHit raycastHit;
    private ISelectable selectable;

    public override void Interact()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out raycastHit, interactionDistance, buttonLayer))
        {
            selectable = raycastHit.transform.GetComponent<ISelectable>();

            if (selectable != null)
            {
                selectable.OnHoverEnter();

                if (playerInput.activatePressed)
                {
                    selectable.OnSelect();
                }
            }
        }

        if (raycastHit.transform == null && selectable != null)
        {
            selectable.OnHoverExit();
            selectable = null;
        }
    }
}
