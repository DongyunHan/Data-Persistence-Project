using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CanvasUIManager : MonoBehaviour
{
    public GameObject username_field;
    public TextMeshProUGUI bestScore_text;


    // Start is called before the first frame update
    void Start()
    {
        bestScore_text.text = "Best Score:" + GameManager.Instance.maxUserName + " : " + GameManager.Instance.maxScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMain(){
        string userName = username_field.GetComponent<TMP_InputField>().text;
        Debug.Log(userName);
        GameManager.Instance.userName = userName;
        SceneManager.LoadScene(1);
    }

    public void Exit(){
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
