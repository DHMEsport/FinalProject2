using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationWalk : MonoBehaviour
{
    private static Animator _animator;
    [SerializeField]  private int _speed;
    [SerializeField] private int _rotationspeed;
    [SerializeField] private int _speedRun;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    

    void Update()
    {
        Move();
    }
    void Move()
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
    
  
}

