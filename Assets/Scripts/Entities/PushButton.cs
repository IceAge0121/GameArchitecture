using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour, ISelectable
{
    /*[SerializeField] private Material defaultMat;
    [SerializeField] private Material hoverMat;
    [SerializeField] private MeshRenderer buttonRenderer;*/

    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit;
    public UnityEvent OnPush;

    public void OnHoverEnter()
    {
        onHoverEnter?.Invoke();
    }

    public void OnHoverExit()
    {
        onHoverExit?.Invoke();
    }

    public void OnSelect()
    {
        OnPush?.Invoke();
    }
}
