using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private TextMeshProUGUI _countdownText;
    private int _objectsCounted { get; set; }
    private int _gameTime { get; set; }
    public bool _isGameActive { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        StartCoroutine(UpdateElapsedGameTime());

    }

    private void Update()
    {
                        
    }

    private void StartGame()
    {
        _playerController.HangshotIsEmpty = true;
        _objectsCounted = 0;
        _gameTime = 60;
        _isGameActive = true;
    }

    private void GameOver()
    {
        _playerController.HangshotIsEmpty = false;
        _isGameActive = false;
        _countdownText.SetText("");
    }

    IEnumerator UpdateElapsedGameTime()
    {
        while (_isGameActive)
        {
            yield return new WaitForSeconds(1);


            if (_isGameActive)
            {
                _gameTime -= 1;
                _countdownText.SetText("Time: " + _gameTime);

                if (_gameTime <= 0)
                {
                    GameOver();
                }
            }
        }
    }

}
