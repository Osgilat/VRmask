using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    private Camera cam;
    public Transform Pricel;
    public GameObject ball;
    GameObject ball_clone;
    public float speed;
    void Start()
    {
        cam = GetComponent<Camera>();

    }

    void Update()
    {
        //Debug.DrawRay(new Vector3(x, 0, z), new Vector3(0, 5f, 0), Color.yellow);
        //if (Input.GetMouseButtonDown(0))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            if (Physics.Raycast(ray, out _))
            {

                ball_clone = Instantiate(ball, Pricel.position, Pricel.rotation);

                Vector3 dest = new Vector3(0, 0.2f, 1.2f);
                ball_clone.GetComponent<Rigidbody>().AddRelativeForce(dest * speed);
                Destroy(ball_clone, 10);
                //ball_clone.GetComponent<Rigidbody>().;//.MovePosition(hit.point * speed);
            }

        }
    }


}
