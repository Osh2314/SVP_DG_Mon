using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panel_Play_Pause;
    public Slider slider_PlayerHp;
    public Slider slider_CoreHp;

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
    public void SetSaveFileNum(int value=0)
    {
        nowSaveFileSelectNum = value;
        if (value == 0)
            Debug.Log("@@@@@@@@nowSaveFIleSelectNum이 0입니다");
    }

    public void LoadInGameScene() {

    }
    
    public void GameExit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();//프로그램 종료
#endif
    }
    //***************************************************************
    //플레이 화면에서 쓰일 함수들**************************************
    public void GameStart()
    {
        LoadSaveData();
        GameManager.Instance.isGamePlaying = true;

        //씬 변경 함수를 이 함수에 삽입해야한다
    }

    void LoadSaveData() {
        //nowSaveFileSelectNum
    }
    public void GamePause()
    {
        Time.timeScale = 0;
    }
    //***************************************************************
}
