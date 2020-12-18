using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private AudioSource _backgroundMusic;
    private float _musicVolume = 0.5f;
    // Start is called before the first frame update

    public void Start()
    {
        _backgroundMusic = GetComponent<AudioSource>();    
    }


    void Update()
    {
        _backgroundMusic.volume = _musicVolume;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void SetVolume(float vol)
    {
        _musicVolume = vol;
    }

    
}
