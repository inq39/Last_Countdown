using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _spherePrefab;
    private GameManager _gameManager;
    public bool HangshotIsEmpty { get; set; }
    private float _slingshotCoolDown = 1.0f;
    public float LastTimeSlingshotFired { get; set; }
    

    private void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        HangshotIsEmpty = true;
        LastTimeSlingshotFired = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (HangshotIsEmpty && (Time.time >= (LastTimeSlingshotFired + _slingshotCoolDown)))
        {
            ReloadSlingshot();
        }       

    } 

    public void ReloadSlingshot()
    {       
            Instantiate(_spherePrefab, _spherePrefab.transform.position, Quaternion.identity);            
            HangshotIsEmpty = false;
    }

}
