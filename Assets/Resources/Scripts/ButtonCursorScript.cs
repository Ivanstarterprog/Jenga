using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCursorScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    private Texture2D _cursorTexture;
    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 _hotSpot = Vector2.zero;

    private void Start()
    {
        _cursorTexture = Resources.Load<Texture2D>("Materials/Cursors/link");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(_cursorTexture, _hotSpot, _cursorMode);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, _cursorMode);
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
        Cursor.SetCursor(null, Vector2.zero, _cursorMode);
    }
}
