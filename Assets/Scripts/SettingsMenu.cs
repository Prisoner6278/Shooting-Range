using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public AudioSource MainMenuSound;

    public AudioSource Click;

    public int levelGenerate;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MainMenuSound.Play();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void ClickSound()
    {
        Click.Play();
    }

    public void Playgame()
    {
        levelGenerate = Random.Range(1, 5);
        SceneManager.LoadScene(levelGenerate);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
