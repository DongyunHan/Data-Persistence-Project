using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MaxScoreText : MonoBehaviour
{
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance != null){
            int maxScore = GameManager.Instance.maxScore;
            string maxUserName = GameManager.Instance.maxUserName;

            myText.text = "Best Score :" + maxUserName+ ": " + maxScore;
        }
    }
}
