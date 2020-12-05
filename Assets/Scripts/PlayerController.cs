using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody _hookRb;
    [SerializeField] 
    private Rigidbody _playerRb;
    private float _maxSpring = 2.0f;
    private float _releaseTime = 0.15f;
    private bool _isTouched = false;
    private float _objectCoordZ;
    private Vector3 _mouseOffset;

    // Update is called once per frame
    void Update()
    {
        if (_isTouched)
        {
            
           /* if (Vector3.Distance(_mousePos, _hookRb.position) > _maxSpring)
            {
                //_playerRb.position = _hookRb.position + (_mousePos - _hookRb.position).normalized * _maxSpring;
            } 
            else
            {
               OnMouseDrag();
            } */
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
        StartCoroutine(ReleaseHook());
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

    IEnumerator ReleaseHook()
    {
        yield return new WaitForSeconds(_releaseTime);
      
        this.enabled = false;

        //GetComponent<SpringJoint>().breakForce = 0;
        // next Sphere
    }

}
