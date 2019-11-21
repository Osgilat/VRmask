using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private CharacterController  _characterController;
    public float GoUp = 60f;
    public float gravity = -9.8f;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    
    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * GoUp;
        float deltaZ = Input.GetAxis("Vertical") * GoUp; 
        Vector3 movement = new Vector3(deltaX , 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, GoUp);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
