using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseLook : MonoBehaviour
   {
   public enum RotationAxes {MouseXandY, MouseX, MouseY}
   public RotationAxes axes = RotationAxes.MouseXandY;
   public float SpeedX = 9.0f, SpeedY = 9.0f, MinY = -45.0f, MaxY = 45.0f;
   private float _rotationX = 0;
    Camera _camera;
    


    void Start()
    {
        _camera = GetComponent<Camera>();
        Rigidbody body = GetComponent<Rigidbody> ();
        if (body != null)
            body.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
    void Update()
            {
                if (axes == RotationAxes.MouseX)
                    {
                        transform.Rotate(0,  Input.GetAxis("Mouse X") * SpeedX, 0);
                    }
                else if (axes == RotationAxes.MouseY)
                    {
                        _rotationX -= Input.GetAxis("Mouse Y") * SpeedY;
                        _rotationX = Mathf.Clamp(_rotationX, MinY, MaxY);
                        float rotationY = transform.localEulerAngles.y;

                        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                    }
                else
                    {
                        _rotationX -= Input.GetAxis("Mouse Y") * SpeedY;
                        _rotationX = Mathf.Clamp(_rotationX, MinY, MaxY);
                        float delta = Input.GetAxis("Mouse X") * SpeedX;
                        float rotationY = delta + transform.localEulerAngles.y;
                        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                    }
            }
   }
