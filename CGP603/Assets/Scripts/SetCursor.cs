using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    public Texture2D m_crosshair;

    void Start()
    {
        Vector2 cursorOffset = new Vector2(m_crosshair.width / 2, m_crosshair.height / 2);
        Cursor.SetCursor(m_crosshair, cursorOffset, CursorMode.Auto);
    }
}