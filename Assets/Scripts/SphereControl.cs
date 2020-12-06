using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{
    private float _maxSpring = 2.0f;
    private bool _isTouched;
    private float _objectCoordZ;
    private Vector3 _mouseOffset;
    private Vector3 _hookRbMidPoint;
    private Rigidbody _hookRbLeft;
    private Rigidbody _hookRbRight;
    private Rigidbody _sphereRb;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _sphereRb = gameObject.GetComponent<Rigidbody>();
        _hookRbLeft = GameObject.FindWithTag("HookRight").GetComponent<Rigidbody>();
        _hookRbRight = GameObject.FindWithTag("HookLeft").GetComponent<Rigidbody>();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        CalculateHookMidPoint();
        _isTouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTouched)
        {


            if (Vector3.Distance(GetMouseAsWorldPoint(), _hookRbMidPoint) > _maxSpring)
            {
                transform.position = _hookRbMidPoint + (GetMouseAsWorldPoint() - _hookRbMidPoint).normalized * _maxSpring;
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
        _sphereRb.isKinematic = true;
        _objectCoordZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        _mouseOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        
    }

    private void OnMouseUp()
    {
        _isTouched = false;
        _sphereRb.isKinematic = false;
        _playerController.HangshotIsEmpty = true;
        _playerController.LastTimeSlingshotFired = Time.time;
    }

    private void CalculateHookMidPoint()
    {
        float _rBHalfDistance = (Vector3.Distance(_hookRbLeft.transform.position, _hookRbRight.transform.position)) / 2.0f;
        _hookRbMidPoint = _hookRbRight.transform.position + new Vector3(0, 0, _rBHalfDistance);
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
}
