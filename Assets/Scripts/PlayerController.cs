using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _hookRb;
    [SerializeField] private Rigidbody _playerRb;
    private float _maxSpring = 2.0f;
    private float _releaseTime = 0.15f;
    private bool _isTouched = false;

    // Update is called once per frame
    void Update()
    {
        if (_isTouched)
        {
            Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(_mousePos, _hookRb.position) > _maxSpring)
            {
                _playerRb.position = _hookRb.position + (_mousePos - _hookRb.position).normalized * _maxSpring;
            } 
            else
            {
                _playerRb.position = _mousePos;
            }
        }
        

    }

    private void OnMouseDown()
    {
        _isTouched = true;
        _playerRb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        
        _isTouched = false;
        _playerRb.isKinematic = false;
        StartCoroutine(ReleaseHook());
    }

    IEnumerator ReleaseHook()
    {
        yield return new WaitForSeconds(_releaseTime);
      
        //this.enabled = false;

        GetComponent<SpringJoint>().breakForce = 5;
        // next Sphere
    }
}
