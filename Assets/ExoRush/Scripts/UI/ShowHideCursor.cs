using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideCursor : MonoBehaviour
{
    public bool StartShowCursor = true;
    // Start is called before the first frame update
    void Start()
    {
        ShowCursor(StartShowCursor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCursor(bool Show)
    {
        Cursor.visible = Show;
    }
}
