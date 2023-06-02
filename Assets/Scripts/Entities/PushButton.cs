using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour, ISelectable
{
    [SerializeField] private Material defaultMat;
    [SerializeField] private Material hoverMat;
    [SerializeField] private MeshRenderer buttonRenderer;


    public UnityEvent OnPush;

    public void OnHoverEnter()
    {
        buttonRenderer.material = hoverMat;
    }

    public void OnHoverExit()
    {
        buttonRenderer.material = defaultMat;
    }

    public void OnSelect()
    {
        OnPush?.Invoke();
    }
}
