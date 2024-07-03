using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    Button gameStart;
    Button gameExit;
    // Start is called before the first frame update
    void Start()
    {
        //Ÿ��Ʋ ȭ�� ��ư����
        gameStart = GameObject.Find("StartButton").GetComponent<Button>();
        gameExit = GameObject.Find("ExitButton").GetComponent<Button>();
        gameStart.onClick.AddListener(GameStart);
        gameExit.onClick.AddListener(GameExit);
        Time.timeScale = 0.5f;
    }
    void GameStart() {
        SceneManager.LoadScene("GameScene");
    }
    void GameExit()
    {
        Application.Quit();
    }
}
