using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameStage currentStage;

    public TextMeshProUGUI dialogueText;

    public static event Action<GameStage> OnStageChange;

    //allows us to grab it from anywhere
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameStage(GameStage.WakeUp);
    }

    public void UpdateGameStage(GameStage newStage)
    {
        currentStage = newStage;

        switch (newStage) {
            case GameStage.WakeUp:
                HandleWakeUp();
                break;
            case GameStage.HouseIntro:
                HandleHouseIntro();
                break;
            case GameStage.InsideHouse:
                HandleInsideHouse();
                break;
            case GameStage.FoundKey:
                HandleFoundKey();
                break;
            case GameStage.ExploredRooms:
                HandleExploredRooms();
                break;
            case GameStage.FinalSequence:
                HandleFinalSequence();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newStage), newStage, null);
        }

        OnStageChange?.Invoke(newStage);
    }

    private void HandleWakeUp()
    {
        //handle logic related
        throw new NotImplementedException();
    }

    private void HandleHouseIntro()
    {
        throw new NotImplementedException();
    }

    private void HandleInsideHouse()
    {
        throw new NotImplementedException();
    }

    private void HandleFoundKey()
    {
        throw new NotImplementedException();
    }

    private void HandleExploredRooms()
    {
        throw new NotImplementedException();
    }

    private void HandleFinalSequence()
    {
        throw new NotImplementedException();
    }
}

public enum GameStage
{
    WakeUp,
    HouseIntro,
    InsideHouse,
    FoundKey,
    ExploredRooms,
    FinalSequence
}
