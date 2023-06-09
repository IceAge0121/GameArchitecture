using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnBehaviour : MonoBehaviour
{
    private PlayerInput playerInput;

    [Header("Player Turn")]
    [SerializeField] private float turnSpeed;

    private void Start()
    {
        playerInput = PlayerInput.GetInstance();
    }
    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * playerInput.mouseX);
    }
}
