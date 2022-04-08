using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _sensitivity = 0.6f;      
    
    private float xRotate = 0f;    

    [SerializeField]
    Camera cam;

    [SerializeField]
    Text _hitScore;
    [SerializeField]
    Text _missScore;
    [SerializeField]
    Text _timeText;
    [SerializeField]
    GameObject _gameOver;

    int _currentHitScore = 0;
    int _currntMissScore = 0;

    float _setTime = 60.0f;


    void Start()
    {
        // Cusor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _timeText.text = _setTime.ToString();
    }
    void Update()
    {
        if (_setTime > 0)
            _setTime -= Time.deltaTime;
        else if (_setTime <= 0)
        {            
            Time.timeScale = 0.0f;
        }

        _timeText.text = Mathf.Round(_setTime).ToString();
            
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
                {
                    _currentHitScore++;
                    _hitScore.text = "Hit : " + _currentHitScore;
                    target.Hit();
                }
                else
                {
                    _currntMissScore++;
                    _missScore.text = "Miss : " + _currntMissScore;
                } 
            }
        }
    }
}
