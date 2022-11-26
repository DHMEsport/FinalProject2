using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerContorller : MonoBehaviour
{
    [SerializeField]  private int _speed;
    [SerializeField] private int _rotationspeed;
    [SerializeField] private int _speedRun;
    [SerializeField] private float isjumping;
    [SerializeField] private float knockbackforce;
    [SerializeField] private Transform knockback;
    BoxCollider _colliderwepon;
    private GameObject objwepon;
    [SerializeField] Transform pivoit;
    public bool isGround = true;
    private Vector3 move;
    private Animator _animator;
    private GameContoller gc;
    private Rigidbody rb;
    private void Start()
  {
        rb = GetComponent<Rigidbody>();
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        if (go != null)
        {
            gc = go.GetComponent<GameContoller>();
        }
        _animator = GetComponent<Animator>();
        objwepon = pivoit.GetChild(0).gameObject;
        _colliderwepon = objwepon.GetComponent<BoxCollider>();
        _colliderwepon.enabled = false;
       
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
            SoundManager.instance.Play(SoundManager.SoundName.hit_enemy);

        }
        else
        {
            _animator.SetBool("IsAttck", false);
        }
        
    }

   public void AttckStart()
    {
        _colliderwepon.enabled = true;
    }

   public void AttckEnd()
    {
        _colliderwepon.enabled = false;
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

            if (moveVertical!=0 && Input.GetKey(KeyCode.Space)&& isGround )
            {
                transform.Translate(0,isjumping,0 );
                isGround = false;
                Debug.Log("is jumping");
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
        if (col.CompareTag("Stair"))
        {
            isGround = true;
            Debug.Log("Is Stair");
        }
        if (col.CompareTag("Enemy"))
        {
            rb.AddForce((Vector3.one) * knockbackforce,ForceMode.Impulse);
            Debug.Log("knock");
        }
    }
}
