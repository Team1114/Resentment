using UnityEngine;
using UnityEngine.Events;

public class EventExample : MonoBehaviour
{
    public UnityEvent TestEvnet;
    public UnityEvent TestEvnet2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            TestEvnet?.Invoke();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            TestEvnet2?.Invoke();
        }
    }
}
