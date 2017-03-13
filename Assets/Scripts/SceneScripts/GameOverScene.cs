using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour {
    public Text ScoreDisplay;

    public void Awake()
    {
        ScoreDisplay.text = PlayerPrefs.GetInt("ScoreFromPlayScene").ToString();
    }


	public void OnHomeButtonTapped()
    {
        TKSceneManager.ChangeScene("StartScene");
    }

    public void OnRetryButtonTapped()
    {
        TKSceneManager.ChangeScene("PlayScene");
    }
}
