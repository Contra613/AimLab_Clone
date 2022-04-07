using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _sensitivity = 0.6f;      
    
    private float xRotate = 0f;    

    [SerializeField]
    Camera cam;

    void Start()
    {
        // Cusor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        MouseRotation();
        Shooter();
    }

    // Controller
    void MouseRotation()
    {
        float yRotationSize = Input.GetAxis("Mouse X") * _sensitivity;
        float yRotate = transform.eulerAngles.y + yRotationSize;

        float xRotationSize = -Input.GetAxis("Mouse Y") * _sensitivity;
        xRotate = Mathf.Clamp(xRotationSize + xRotate, -80, 80);

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }

    // Shoot
    void Shooter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();

                if (target != null)
                    target.Hit();
            }
        }
    }
}
