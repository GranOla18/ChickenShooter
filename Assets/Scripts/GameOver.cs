using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameManager gM;
    public ChickenManager chicken;
    public Canvas chickenHUD;
    public Canvas gameOverCanvas;
    public Text finalScore;

    // Update is called once per frame
    void Update()
    {
        if (chicken.health <= 0)
        {
            Time.timeScale = 0;
            gM.isPlaying = false;
            chickenHUD.enabled = false;
            gameOverCanvas.enabled = true;
            finalScore.text = "Final Score: " + chicken.score.ToString();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
