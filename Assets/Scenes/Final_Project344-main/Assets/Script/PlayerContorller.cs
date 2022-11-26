using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    [SerializeField]  private int _speed;
    [SerializeField] private int _rotationspeed;
    [SerializeField] private int _speedRun;
    [SerializeField] private int healdown;
    [SerializeField] private EnemyMove _enemyMove;
    private Animator _animator;
    private GameContoller gc;
  private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        if (go != null)
        {
            gc = go.GetComponent<GameContoller>();
        }
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        OnClickAttck();
        OnMove();
    }
 
    private void OnClickAttck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("IsAttck", true);
        }
        else
        {
            _animator.SetBool("IsAttck", false);
        }
        
    }
    private void OnMove()
    {
        float moveVertical = Input.GetAxis("Vertical") * _speed;
        float moveHorizontal = Input.GetAxis("Horizontal") * _rotationspeed;
        transform.Translate(0,0,moveVertical * Time.deltaTime);
        transform.Rotate(0,moveHorizontal * Time.deltaTime,0);
        moveVertical *= Time.deltaTime;
    
        if (moveVertical != 0)
        {
            _animator.SetBool("IsWalk",true);
            _animator.SetBool("IsRun",false);
            if (moveVertical != 0 && Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetBool("IsRun",true);
                transform.Translate(0,0,moveVertical*_speedRun );
            }
        }
        else
        {
            _animator.SetBool("IsWalk",false);
            _animator.SetBool("IsRun",false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            gc.UpdateHeal(-healdown);
            Debug.Log("HIT Enemy");
        }
    }
}
