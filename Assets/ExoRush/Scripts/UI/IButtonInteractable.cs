using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IButtonInteractable
{
    void OnButtonClicked();
    void OnItemHighlighted();
    void OnItemLeft();
}
