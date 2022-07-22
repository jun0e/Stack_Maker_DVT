
using UnityEngine;




public abstract class Stacks : MonoBehaviour
{
    [SerializeField] public Material offMat; 
    public MeshRenderer m_meshRenderer;
    public enum State //Abstract with this later
    {
        on=1,
        off=0
    }
    public State state;

    public void Activate()
    {
        state = State.on;
    }

    public void Initialize()
    {
        state = State.off;
    }

    private void Start()
    {
        Initialize();

    }


    
   
}