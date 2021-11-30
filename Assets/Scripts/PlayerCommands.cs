using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommands : MonoBehaviour
{
    Camera _camera = null;
    RaycastHit _hitInfo;

    CommandInvoker _commandInvoker = new CommandInvoker();

    [SerializeField] GameObject _player;
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _tile;

    [SerializeField] Button _attackBtn = null;
    [SerializeField] Button _healBtn = null;
    [SerializeField] GameObject _greyoutAttackImg;
    [SerializeField] GameObject _greyoutHealImg;

    public bool _selected = false;
    bool _canAttack = false;
    bool _canHeal = true;
    bool _hasAction = true;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_selected == false)
            {
                SelectCharacter();
            }
            else if (_selected == true && _canAttack == true && _hasAction == true)
            {
                Attack();
            }
            else if (_selected == true && _canHeal == true && _hasAction == true)
            {
                Heal();
            }
        }

        if (_selected == true)
        {
            ShowActions();
        }
        else if (_selected == false)
        {
            HideActions();
            _tile.GetComponent<Tile>().occupied = false;
        }

        // Undo last command
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Undo();
        }
    }

    void SelectCharacter()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out _hitInfo, Mathf.Infinity))
        {
            Debug.Log("Ray hit: " + _hitInfo.transform.name);

            if (_hitInfo.transform.gameObject.tag == "Player")
            {
                _selected = true;
                _tile.GetComponent<Tile>().occupied = true;
                Debug.Log("Player selected.");
            }
        }
    }
    private void Attack()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hitInfo, Mathf.Infinity))
        {
            if (_hitInfo.transform.gameObject.tag == "Enemy")
            {
                Debug.Log("Attacked enemy");
                _enemy.GetComponent<Health>().TakeDamage(5);
                Debug.Log("Enemy Health: " + _enemy.GetComponent<Health>()._currentHealth);

                _hasAction = false;
                _selected = false;
                Debug.Log("No Player selected.");
            }
        }
    }

    public void Heal()
    {
        //Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out _hitInfo, Mathf.Infinity))
        //{
            //if (_hitInfo.transform.gameObject.tag == "Player")
            //{
                _player.GetComponent<Health>().Heal(3);
                Debug.Log("Healed player. Health: " + GetComponent<Health>()._currentHealth);

                _hasAction = false;
                _selected = false;
                Debug.Log("No Player selected.");
            //}
        //}
    }

    void ShowActions()
    {
        _attackBtn.gameObject.SetActive(true);
        _healBtn.gameObject.SetActive(true);

        if (_hasAction == false)
        {
            _greyoutAttackImg.SetActive(true);
            _greyoutHealImg.SetActive(true);
        }
        
    }

    void HideActions()
    {
        _attackBtn.gameObject.SetActive(false);
        _healBtn.gameObject.SetActive(false);
    }

    public void CanAttack()
    {
        _canAttack = true;
    }

    public void CanHeal()
    {
        _canHeal = true;
    }

    public void Reset()
    {
        _hasAction = true;
        _canHeal = true;
        _canAttack = true;
    }

    public void Deselect()
    {
        _selected = false;
        _greyoutAttackImg.SetActive(false);
        _greyoutHealImg.SetActive(false);
    }

    public void Undo()
    {
        _commandInvoker.UndoCommand();
    }
}
