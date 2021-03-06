using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnGameState : GameState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] Button _healBtn = null;
    [SerializeField] Button _attackBtn = null;

    [SerializeField] GameObject _player;

    int _playerTurnCount = 0;

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        _playerTurnTextUI.gameObject.SetActive(true);
        _player.GetComponent<PlayerCommands>().Reset();

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
        // hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
        _healBtn.gameObject.SetActive(false);
        _attackBtn.gameObject.SetActive(false);
        _player.GetComponent<PlayerCommands>().Deselect();
        // unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;

        Debug.Log("Player Turn: Exiting...");
    }

    void OnPressedConfirm()
    {
        StateMachine.ChangeState<EnemyTurnGameState>();
    }
}
