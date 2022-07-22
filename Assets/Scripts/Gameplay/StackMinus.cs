using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackMinus : Stacks
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (state == State.off)
            {
                Activate();
                //m_meshRenderer.material = offMat;
                collision.transform.position += new Vector3(0, -0.3f, 0);
            }

        }

    }
}
