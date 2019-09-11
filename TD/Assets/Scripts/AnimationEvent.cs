using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public UnityEvent animEvent;

    public void CallEvent()
    {
        animEvent.Invoke();
    }
}
