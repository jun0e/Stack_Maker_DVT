using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 startPos;
    public Vector3 targetPos;
    public int pixelDistanceToDetect = 50;
    private bool fingerDown;

    
    
    public bool offTrigger=false;
    public float timeCheck= 100f;




    public Rigidbody rb;
    
    



    public float moveSpeed = 20f;
    

    //public float stationaryTolerance = 0.005f;
    public enum Direction
    {
        up,
        down,
        left,
        right
    }
    public Direction headTo;


    void Start()
    {
        targetPos = transform.position;

        rb = GetComponent<Rigidbody>();
        offTrigger = false;
        
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(1))
        {
            StackUp();
        }
        if (Input.GetMouseButtonUp(2))
        {
            StackDown();
        }
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("pushed babe");
        //}

        if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
            offTrigger = true;

        }

        if (fingerDown)
        {
            if (Input.mousePosition.y >= startPos.y + pixelDistanceToDetect)
            {
                fingerDown = false;
                //Debug.Log("Swipe Up");
                headTo = Direction.up;
            }
            else if (Input.mousePosition.x <= startPos.x - pixelDistanceToDetect)
            {
                fingerDown = false;
                //Debug.Log("Swipe Left");
                headTo = Direction.left;
            }
            else if (Input.mousePosition.x >= startPos.x + pixelDistanceToDetect)
            {
                fingerDown = false;
                //Debug.Log("Swipe Right");
                headTo = Direction.right;
            }
            else if (Input.mousePosition.y <= startPos.y - pixelDistanceToDetect)
            {
                fingerDown = false;
                //Debug.Log("Swipe Down");
                headTo = Direction.down;
            }
        }

        if (fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }

        
    }

    private void FixedUpdate()
    {
        //if (CheckHit()) Debug.Log(gameObject.tag);
        Move(headTo);
    }

    //public bool CheckHit()
    //{
    //    bool ray = Physics.Raycast(transform.position, Vector3.forward);

    //    return ray;
    //}
    public void Move(Direction headTo)
    {
        switch (headTo)
        {
            case Direction.up:
                targetPos = transform.position + Vector3.forward;
               
                break;

            case Direction.down:
                targetPos = transform.position + Vector3.back;
               
                break;

            case Direction.left:
                targetPos = transform.position + Vector3.left;
                
                break;

            case Direction.right:
                targetPos = transform.position + Vector3.right;
                
                break;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        

    }


    public void StackUp()
    {
        transform.position += new Vector3(0, 0.3f, 0);


    }

    public void StackDown()
    {
        transform.position -= new Vector3(0, 0.3f, 0);
    }

    
}









