using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JengaCursorScript : MonoBehaviour
{
    private Texture2D _cursorTextureMouseOver;
    private Texture2D _cursorTextureMouseDrag;
    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 _hotSpot = Vector2.zero;

    private void Start()
    {
        _cursorTextureMouseOver = Resources.Load<Texture2D>("Materials/Cursors/link");
        _cursorTextureMouseDrag = Resources.Load<Texture2D>("Materials/Cursors/move");
    }

    public void OnMouseOver()
    {
        if (!Input.GetMouseButton(0) && !GameManager.instance.isPaused && !GameManager.instance.isGameEnded)
        {
            Cursor.SetCursor(_cursorTextureMouseOver, _hotSpot, _cursorMode);
        }
    }

    public void OnMouseDrag()
    {
        if(!GameManager.instance.isPaused && !GameManager.instance.isGameEnded)
        {
            Cursor.SetCursor(_cursorTextureMouseDrag, _hotSpot, _cursorMode);
        }
    }

    public void OnMouseUp()
    {
        if (!GameManager.instance.isPaused && !GameManager.instance.isGameEnded)
        {
            Cursor.SetCursor(null, _hotSpot, _cursorMode);
        }
    }

    public void OnMouseExit()
    {
        if (!Input.GetMouseButton(0) && !GameManager.instance.isPaused && !GameManager.instance.isGameEnded)
        {
            Cursor.SetCursor(null, _hotSpot, _cursorMode);
        }
    }
}
