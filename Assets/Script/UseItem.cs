using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UseItem : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private int healup ;
    [SerializeField] private int healmax ;
    [SerializeField] private GameObject heal;
    [SerializeField] private GameObject UI;
    private GameContoller gc;
    private bool ispressed = false;
    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        if (go != null)
        {
            gc = go.GetComponent<GameContoller>();
        }
    }
    public void Update()
    {
        if (ispressed && healmax<=100)
        {
            gc.UpdateHeal(+healup);
            if (healup >= 50)
            {
                ispressed = false;
                Debug.Log("No heal");
            }
            gc.UpdateLive(0);
            Destroy(UI.gameObject);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}
