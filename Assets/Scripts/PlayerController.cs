using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _hookRbLeft;  
    private Rigidbody _hookRbRight;
    private Rigidbody _playerRb;
    private GameManager _gameManager;
    private float _maxSpring = 2.0f;
    private bool _isTouched = false;
    private float _objectCoordZ;
    private Vector3 _mouseOffset;
    private Vector3 _hookRbMidPoint;
    [SerializeField]
    private GameObject _spherePrefab;
    public bool HangshotIsEmpty { get; set; }
    private float _reloadSlingshotTime = 2.0f;
    private float _lastReloadTime = -2.0f;

    private void Start()
    {
        _playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        _hookRbLeft = GameObject.FindWithTag("HookRight").GetComponent<Rigidbody>();
        _hookRbRight = GameObject.FindWithTag("HookLeft").GetComponent<Rigidbody>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        calculateHookMidPoint();
        Instantiate(_spherePrefab, _spherePrefab.transform.position, Quaternion.identity);
        HangshotIsEmpty = false;
    }

    private void calculateHookMidPoint()
    {
        float _rBHalfDistance = (Vector3.Distance(_hookRbLeft.transform.position, _hookRbRight.transform.position)) / 2.0f;
        _hookRbMidPoint = _hookRbRight.transform.position + new Vector3(0, 0, _rBHalfDistance);
    }


    // Update is called once per frame
    void Update()
    {
        if (_isTouched)
        {
            
            if (Vector3.Distance(GetMouseAsWorldPoint(), _hookRbMidPoint) > _maxSpring)
            {
                transform.position = _hookRbMidPoint + (_mouseOffset - _playerRb.position).normalized * _maxSpring;
            } 
            else
            {
               OnMouseDrag();
            } 
        }
        

    }

    private void OnMouseDown()
    {
        _isTouched = true;
        _playerRb.isKinematic = true;
        _objectCoordZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        _mouseOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private void OnMouseUp()
    {
        _isTouched = false;
        _playerRb.isKinematic = false;
        HangshotIsEmpty = true;
        ReloadSlingshot();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 _mousePosition = Input.mousePosition;
        _mousePosition.z = _objectCoordZ;
        return Camera.main.ScreenToWorldPoint(_mousePosition);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + _mouseOffset;
    }

    private void ReloadSlingshot()
    {
        float _elapsedTime = Time.time - _lastReloadTime;

        if (HangshotIsEmpty && (_elapsedTime >= _reloadSlingshotTime))
        {
            Instantiate(_spherePrefab, _spherePrefab.transform.position, Quaternion.identity);
            HangshotIsEmpty = false;
            _lastReloadTime = Time.time;
        }
    }
}
