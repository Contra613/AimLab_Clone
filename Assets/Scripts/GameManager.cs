using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Text _hitScore;
    public Text _missScore;

    private int _currentHitScore = 0;
    private int _currntMissScore = 0;

    public static bool _isPause = false;


    void Start()
    {
        
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (_isPause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Timer()
    {

    }

    public void hitCount()
    {
        _currentHitScore++;
        _hitScore.text = "Hit : " + _currentHitScore;
    }

    public void missCount()
    {
        _currntMissScore++;
        _missScore.text = "Miss : " + _currntMissScore;
    }
}
