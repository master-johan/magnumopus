using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{

    GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player"); 
        offset = target.transform.position - transform.position;
        
    }

    void LateUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);


        float desiredAngleY = target.transform.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(0, desiredAngleY, 0);
        transform.position = target.transform.position - (rotation* offset);

        transform.LookAt(target.transform);
        transform.Rotate(-25, 0, 0);

    }
}
