using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject ladderPrefab;

    public int lengthOfLadder;

    List<GameObject> listLadder = new List<GameObject>();

    int playerPoint;
    int xPos = 0;

    private void Start()
    {
        for (int i = 0; i < lengthOfLadder; i++)
        {
            GameObject ladder = Instantiate(ladderPrefab) as GameObject;
            ladder.name = i.ToString();

            if (xPos < 70) xPos += Random.Range(40, 70);
            else if (xPos >= 110) xPos -= Random.Range(40, 70);
            else xPos += Random.Range(-60, 60);
            ladder.transform.position = new Vector3(xPos, -175 + (i * 250), 0);

            listLadder.Add(ladder);
        }
    }
}