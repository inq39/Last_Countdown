using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI _counterText;

    private int _count = 0;

    
    private void OnTriggerEnter(Collider other)
    {
        _count += 1;
        _counterText.text = "Count: " + _count;
    }
}
