using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private AudioSource _backgroundMusic;
    private float _musicVolume = 0.5f;
    
    [SerializeField] Image _menu1;
    [SerializeField] Image _menu2;
    [SerializeField] GameObject _HUD;
    [SerializeField] GameObject _resumeMenu;
    private Color _alpha1;
    private Color _alpha2;
    // Start is called before the first frame update

    public void Start()
    {
        _backgroundMusic = GetComponent<AudioSource>();
        _alpha1 = _menu1.color;
        _alpha2 = _menu2.color;
    }


    void Update()
    {
        _backgroundMusic.volume = _musicVolume;
        _menu1.color = _alpha1;
        _menu2.color = _alpha2;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResumeGame()
    {
        _HUD.SetActive(true);
        _resumeMenu.SetActive(false);
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

    public void AdjustHUDTransparency(float alpha)
    {
        _alpha1.a = alpha;
        _alpha2.a = alpha;
    }
    
    public void PressPauseButton()
    {
        _HUD.SetActive(false);
        _resumeMenu.SetActive(true);
    }
}
