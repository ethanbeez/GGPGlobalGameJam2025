using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour {
    [SerializeField] private int gameLengthMinutes = 30;
    [SerializeField] private float gameSpeedMultiplier = 3;
    [Header("Scene Hooks")]
    [SerializeField] TextMeshPro timerTextComponent;

    private float timeLeft;
    [SerializeField] private bool timerActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        timerActive = false;
        timeLeft = gameLengthMinutes * 60;
    }

    // Update is called once per frame
    void Update() {
        if (timerActive && timeLeft > 0) { 
            timeLeft -= Time.deltaTime * gameSpeedMultiplier;
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay() {
        float minutesLeft = Mathf.FloorToInt(timeLeft / 60);
        float secondsLeft = Mathf.FloorToInt(timeLeft % 60);
        timerTextComponent.text = string.Format("{0:00}:{1:00}", minutesLeft, secondsLeft);
    }

    public void Activate() { 
        timerActive = true;
    }
}
