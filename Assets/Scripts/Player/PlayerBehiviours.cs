using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehiviours : MonoBehaviour
{
    protected int pathNumber = 0;
    [SerializeField] protected float swipeLenght=100;
    [SerializeField] protected float moveSidesSpeed = 10;
    private Vector3 startMousePos;
    private Vector3 endMousePos;
    private float swipeValue;
    private Vector3 playerStartPos;
    protected virtual void Start()
    {
        playerStartPos = transform.position;
    }

   protected virtual void Update()
    {
        Swipe();
        MouseSwipe();
    }
	
    private void MouseSwipe()
    {
        if (swipeValue > swipeLenght && pathNumber == 0)
        {
            MovePlayerValue(GameManager.Instance.pathSidesValue, () =>
            {
                swipeValue = 0;
                pathNumber = 1;
            });
        }
        else if (swipeValue > swipeLenght && pathNumber == -1)
        {
            MovePlayerValue(0, () =>
            {
                swipeValue = 0;
                pathNumber = 0;
            });
        }
        else if (swipeValue < -swipeLenght && pathNumber == 0)
        {
            MovePlayerValue(-GameManager.Instance.pathSidesValue, () =>
            {
                swipeValue = 0;
                pathNumber = -1;
            });
        }
        else if (swipeValue < -swipeLenght && pathNumber == 1)
        {
            MovePlayerValue(0, () =>
            {
                swipeValue = 0;
                pathNumber = 0;
            });
        }
    }
    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            startMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endMousePos = Input.mousePosition;
            swipeValue = endMousePos.x - startMousePos.x;
        }
    }
    private void MovePlayerValue(float moveValue,Action onReachPosition) 
    {
        Vector3 localMoveAmount;
        localMoveAmount = new Vector3(moveValue, 0,0);
        transform.position = Vector3.MoveTowards(transform.position, playerStartPos+ localMoveAmount, Time.deltaTime* moveSidesSpeed);
        if (Vector3.Distance(transform.position , playerStartPos + localMoveAmount) ==0) 
        {
            onReachPosition?.Invoke();
        }
    }
}
