using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    ScrollRect anotherScrollRect;
    private Image thisRaycast;

    void Start()
    {
        FindScrollRect(gameObject);
        if (anotherScrollRect)
        {
            thisRaycast = gameObject.GetComponent<Image>();
        }
    }

    private void FindScrollRect(GameObject obj)
    {
        GameObject tempObj = obj?.transform?.parent?.gameObject;
        if (!tempObj) return;
        anotherScrollRect = tempObj.GetComponent<ScrollRect>();
        if (anotherScrollRect)
        {
            return;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (anotherScrollRect)
        {
            anotherScrollRect.OnBeginDrag(eventData);
        }
        if (thisRaycast)
        {
            thisRaycast.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (anotherScrollRect)
        {
            anotherScrollRect.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (anotherScrollRect)
        {
            anotherScrollRect.OnEndDrag(eventData);
        }
        if (thisRaycast)
        {
            thisRaycast.raycastTarget = true;
        }
    }
}