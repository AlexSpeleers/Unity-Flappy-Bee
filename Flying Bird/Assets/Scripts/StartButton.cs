using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameMusic;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        transform.localScale = Vector3.zero;
        Time.timeScale = 1f;
        if (audioSource && gameMusic)
        {
            audioSource.clip = gameMusic;
            audioSource.loop = gameMusic;
            audioSource.Play();
        }
    }
}
