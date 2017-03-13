using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    public InputField playerNameInput;
    public Text playerRank;
    public Text playerName;
    public Text playerScore;
    public Button submitNameButton;
    public GameObject highScoreListPanel;

    /*private void Awake()
    {
        playerRank = GetComponent<Text>();
        playerName = GetComponent<Text>();
        playerRank = GetComponent<Text>();
    }*/

    class Players : IComparable
    {
        public int score;
        public string playerName;
        public Players(string playerName, int score)
        {
            this.score = score;
            this.playerName = playerName;
        }

        public int CompareTo(Players other)
        {
            if (score > other.score) return 1;
            else if (score < other.score) return -1;
            else return 0;
        }

        public int GetScore()
        {
            return score;
        }

        public string GetPlayerName()
        {
            return playerName;
        }

        public int CompareTo(object obj)
        {
            Players other = (Players) obj;
            if (other.score > score) return 1;
            if (other.score < score) return -1;
            return 0;
        }
    }

    List<Players> listHighScore = new List<Players>();

    void UpdateHighScoreList()
    {
        highScoreListPanel.gameObject.SetActive(true);
        playerName.gameObject.SetActive(true);
        playerScore.gameObject.SetActive(true);
        playerRank.gameObject.SetActive(true);
        listHighScore.Clear();
        Debug.Log(listHighScore.Count);
        int listLength = PlayerPrefs.GetInt("listLength");
        Debug.Log(listLength);

        for (int i = 0; i < listLength; i++)
        {
            Players player = new Players(PlayerPrefs.GetString("Player" + i.ToString()), PlayerPrefs.GetInt("Score" + i.ToString()));
            listHighScore.Add(player);
        }

        listHighScore.Sort();
        Debug.Log(listHighScore.Count);
        Debug.Log(listLength);

        while (listLength >= 11)
        {
            listHighScore.RemoveAt(listLength - 1);
            listLength--;
        }


        Debug.Log(listHighScore.Count);
        Debug.Log(listLength);
        PlayerPrefs.SetInt("listLength", listLength);
        PlayerPrefs.Save();
        playerRank.text = "Rank\n";
        playerScore.text = "Score\n";
        playerName.text = "Player Name\n";
        Debug.Log(listLength);
        Debug.Log("======================");
        Debug.Log(listHighScore.Count);

        for (int i = 0; i < listHighScore.Count; i++)
        {
            Debug.Log("Loop OK");
            playerRank.text += ((i+1).ToString() + "\n");
            playerName.text += (listHighScore[i].GetPlayerName() + "\n");
            playerScore.text += (listHighScore[i].GetScore() + "\n");

            PlayerPrefs.SetInt("Score" + i.ToString(), listHighScore[i].GetScore());
            PlayerPrefs.Save();
            PlayerPrefs.SetString("Player" + i.ToString(), listHighScore[i].GetPlayerName());
            PlayerPrefs.Save();
        }

        Debug.Log(listLength);

    }

    public void OnSubmitPlayerName()
    {
        int listLength = PlayerPrefs.GetInt("listLength");
        int scoreFromPlayScene = PlayerPrefs.GetInt("ScoreFromPlayScene");
        string playerName = playerNameInput.text;
        PlayerPrefs.SetString("Player" + (listLength - 1).ToString(), playerName);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("Score" + (listLength - 1).ToString(), scoreFromPlayScene);
        PlayerPrefs.Save();
        Debug.Log("Player Name: " + playerName + ". Score: " + scoreFromPlayScene + ".");
        UpdateHighScoreList();
        highScoreListPanel.gameObject.SetActive(true);
        playerNameInput.gameObject.SetActive(false);
        submitNameButton.gameObject.SetActive(false);
        Debug.Log(listLength);

    }

    public void ClearBoard()
    {
        PlayerPrefs.DeleteAll();
        playerRank.text = "Rank\n";
        playerName.text = "Player Name\n";
        playerScore.text = "Score\n";
    }


}
