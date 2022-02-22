using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private bool pointerDown;

    public UnityEvent onLongClick;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            if (onLongClick != null)
            {
                onLongClick.Invoke();
            }                   
        }
    }
}
