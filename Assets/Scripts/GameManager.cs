using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController.HangshotIsEmpty = true;
      
    }



    /*IEnumerator UpdateTime()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);


            if (isGameActive)
            {
                time -= 1;
                timeText.text = "Time: " + time;

                if (time <= 0)
                {
                    GameOver();
                }
            }
        }
    }*/
}
