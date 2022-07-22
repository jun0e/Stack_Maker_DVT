using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : Stacks
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (state == State.off)
            {
                Activate();
                //m_meshRenderer.material = offMat;
                Debug.Log("you won, yay");
            }

        }

    }
}
