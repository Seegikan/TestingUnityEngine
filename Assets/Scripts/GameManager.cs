using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public IScore Score { get; set; }
    private MainUI _mainUI;

    public MainUI GetMainUI => _mainUI;

    public GameManager()
    {
        Score = new Score();
    }

    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

