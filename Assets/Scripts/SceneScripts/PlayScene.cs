using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayScene : MonoBehaviour {
    public static PlayScene Instance { get; private set;}
    public Text scoreDisplay;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Score()
    {
        score++;
        scoreDisplay.text = score.ToString();
    }


    public void OnHomeButtonTapped()
    {
        TKSceneManager.ChangeScene("StartScene");
    }
    
    public void GameOver()
    {
        int listLength = PlayerPrefs.GetInt("listLength");
        FindObjectOfType<CameraController>().ScreenShake();
        PlayerPrefs.SetInt("ScoreFromPlayScene", score);
        PlayerPrefs.Save();

        listLength++;
        PlayerPrefs.SetInt("listLength", listLength);
        PlayerPrefs.Save();

        StartCoroutine(AnimateGameOver());
    }
    private IEnumerator AnimateGameOver()
    {
        yield return new WaitForSeconds(1);
        TKSceneManager.ChangeScene("GameOverScene");
    }
}
