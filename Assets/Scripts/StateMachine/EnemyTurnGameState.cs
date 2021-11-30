using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnGameState : GameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;

    bool acted = false;

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();
        acted = false;

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy performs action");
        if(enemy.GetComponent<Health>()._currentHealth <= 8)
        {
            enemy.GetComponent<Health>().Heal(3);
            Debug.Log("Enemy Healed");
            acted = true;
        }
        else
        {
            Attack();
        }

        EnemyTurnEnded?.Invoke();
        // turn over. Go back to player
        ChangeState();

    }

    void Attack()
    {
        player.GetComponent<Health>().TakeDamage(5);
        Debug.Log("Enemy attacked");
        acted = true;
    }

    void ChangeState()
    {
        if(acted == true)
        {
            StateMachine.ChangeState<PlayerTurnGameState>();
        }
    }
}
