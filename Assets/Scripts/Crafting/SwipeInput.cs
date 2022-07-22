using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

namespace Controller
{
    public class SwipeInput : MonoBehaviour
    {
        static readonly float MIN_THRESHHOLD = 50f;

        public Direction headTo;
        public Vector3 directionVector3;

        private bool fingerDown;
        private Vector2 startPos;



        public Direction PointTo()
        {
            //NOTE original game allow multiple swipe while hold down |remove fingerDown off with each swipe, update startPos each loop?
            //finger touch down check
            if (fingerDown == false && Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                fingerDown = true;
            }
            //swipe detect
            if (fingerDown)
            {
                if (Input.mousePosition.y >= startPos.y + MIN_THRESHHOLD)
                {
                    fingerDown = false;
                    headTo = Direction.up;
                    Debug.Log("heup");
                    directionVector3 = Vector3.forward;
                }
                else if (Input.mousePosition.x <= startPos.x - MIN_THRESHHOLD)
                {
                    fingerDown = false;
                    headTo = Direction.left;
                    Debug.Log("helef");
                    directionVector3 = Vector3.back;

                }
                else if (Input.mousePosition.x >= startPos.x + MIN_THRESHHOLD)
                {
                    fingerDown = false;
                    headTo = Direction.right;
                    directionVector3 = Vector3.left;

                }
                else if (Input.mousePosition.y <= startPos.y - MIN_THRESHHOLD)
                {
                    fingerDown = false;
                    headTo = Direction.down;
                    directionVector3 = Vector3.left;

                }
            }

            if (fingerDown && Input.GetMouseButtonUp(0))
            {
                fingerDown = false;
            }

            return headTo;

        }

    }
}
