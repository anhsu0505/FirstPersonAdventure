using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timing : MonoBehaviour
{
    AudioSource _audiosource;
    //public AudioSource dieSound;
    public AudioClip loseSound;
    public TextMeshProUGUI countdownTextUI;
    public GameObject gameOverUI;
    public GameObject hangGrabberUI;
    public float timerInitial = 305f;

    private bool stopTimer;
    private bool playDieAudio;
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        stopTimer = false;
        playDieAudio = false;
    }

    void Update()
    {
        float currentTimeRemain = timerInitial - Time.timeSinceLevelLoad;

        int minutes = Mathf.FloorToInt(currentTimeRemain / 60f);
        int seconds = Mathf.FloorToInt(currentTimeRemain - minutes * 60);

        string formattedTextTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (currentTimeRemain <= 0)
        {
            stopTimer = true;
            if (playDieAudio == false)
            {
                playDieAudio = true;   
                StartCoroutine(LoadMainScreen("MainMenu"));
            }
        }

        if (stopTimer == false)
        {
            countdownTextUI.text = formattedTextTime;
        }

    }

    public void PenalizeTime()
    {
        timerInitial = timerInitial - 60f;
    }

    IEnumerator LoadMainScreen(string level)
    {
        gameOverUI.SetActive(true);
        hangGrabberUI.SetActive(false);
        _audiosource.PlayOneShot(loseSound);
        //dieSound.Play();

        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene(level);
    }

}
