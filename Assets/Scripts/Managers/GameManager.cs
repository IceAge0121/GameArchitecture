using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager[] levels;

    public static GameManager instance;

    private GameState currentState;
    private LevelManager currentLevel;
    private int currentLevelIndex = 0;
    private bool isInputActive = true;

    public enum GameState
    {
        Briefing,
        LevelStart,
        LevelIn,
        LevelEnd,
        GameOver,
        GameEnd
    }
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        if(levels.Length > 0)
        {
            ChangeState(GameState.Briefing, levels[currentLevelIndex]);
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public bool IsInputActive()
    {
        return isInputActive;
    }

    public void ChangeState(GameState state, LevelManager level)
    {
        currentState = state;
        currentLevel = level;

        switch(currentState)
        {
            case GameState.Briefing:
                StartBriefing();
                break;
            case GameState.LevelStart:
                InitialLevel();
                break;
            case GameState.LevelIn:
                RunLevel();
                break;
            case GameState.LevelEnd:
                CompleteLevel();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameEnd:
                GameEnd();
                break;
        }
    }

    private void StartBriefing()
    {
        Debug.Log("level started...done!");

        isInputActive = false;

        ChangeState(GameState.LevelStart, currentLevel);
    }

    private void InitialLevel()
    {
        Debug.Log("Level Start");

        isInputActive = true;

        currentLevel.StartLevel();
        ChangeState(GameState.LevelIn, currentLevel);
    }

    private void RunLevel()
    {
        Debug.Log("Level In " + currentLevel.gameObject.name);
    }

    private void CompleteLevel()
    {
        Debug.Log("Level end");

        ChangeState(GameState.LevelStart, levels[++currentLevelIndex]);
    }

    private void GameOver()
    {
        Debug.Log("Game over, you lose");
    }

    private void GameEnd()
    {
        Debug.Log("Game end, you win!");
    }
}
