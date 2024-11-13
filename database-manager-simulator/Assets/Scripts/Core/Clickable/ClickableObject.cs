using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        ClickHandler();
    }

   
    protected abstract void ClickHandler();
}
