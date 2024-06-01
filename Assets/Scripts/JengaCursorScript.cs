using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JengaCursorScript : MonoBehaviour
{
    public Texture2D cursorTextureMouseOver;
    public Texture2D cursorTextureMouseDrag;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void OnMouseOver()
    {
        if (!Input.GetMouseButton(0) && !GameManager.instance.isPaused && !GameManager.instance.isGameEnded)
        {
            Cursor.SetCursor(cursorTextureMouseOver, hotSpot, cursorMode);
        }
    }

    public void OnMouseDrag()
    {
        if(!GameManager.instance.isPaused && !GameManager.instance.isGameEnded)
        {
            Cursor.SetCursor(cursorTextureMouseDrag, new Vector2(16, 16), cursorMode);
        }
        else
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }

    public void OnMouseUp()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }

    public void OnMouseExit()
    {
        if (!Input.GetMouseButton(0))
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }
}
