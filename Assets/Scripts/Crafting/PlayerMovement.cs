using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;
namespace Controller
{
    
    public class PlayerMovement : MonoBehaviour
    {
        
        public Vector3 startPos;
        public Vector3 targetPos;
        public Vector3 moveVector3;
        Direction headTo;

        Rigidbody rb;

        [SerializeField]
        private float moveSpeed = 10f;

        //GameObject input = new SwipeInput();

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            //headTo = Controller.SwipeInput.PointTo();
        }

        void FixedUpdate()
        {
            Steer(headTo);
            if (CheckHit()) Debug.Log("he");
            Move(moveVector3);
        }

        public void Steer(Direction headTo)
        {
            switch (headTo)
            {
                case Direction.up:
                    moveVector3 = Vector3.forward;
                    break;

                case Direction.down:
                    moveVector3 = Vector3.back;
                    break;

                case Direction.left:
                    moveVector3 = Vector3.left;
                    break;

                case Direction.right:
                    moveVector3 = Vector3.right;
                    break;
            }
        }
        public void Move(Vector3 moveVector3)
        {
            
            targetPos = transform.position + moveVector3;
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);


        }
        public bool CheckHit()
        {
            bool ray = Physics.Raycast(transform.position, Vector3.back);

            return ray;
        }
    }
}