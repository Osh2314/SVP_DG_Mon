using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panel_Play_Pause;
    public int nowSaveFileSelectNum;

    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static UIManager instance;
    
    private void Awake()
    {
        if (UIManager.Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    //메인화면에서 쓸 함수들*****************************************
    public void GameStartWithSaveFileNum(int value=0)
    {
        nowSaveFileSelectNum = value;
        if (value == 0)
            Debug.Log("@@@@@@@@nowSaveFIleSelectNum이 0입니다");
        GameManager.Instance.isGamePlaying = true;

        //씬 변경 함수를 이 함수에 삽입해야한다
    }

    public void GamePause() {
        Time.timeScale = 0;
    }
    public void GameExit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();//프로그램 종료
#endif
    }
    //***************************************************************
}
