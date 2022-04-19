using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
struct CellGridPos
{
    public Vector2 pos;
    public IButtonInteractable item;
}

public class GamepadMapper : MonoBehaviour
{
    [SerializeField] private float axisThreshold = 0.8f;
    [Tooltip("if active, the script won't be detecting keys already preesed when activated")]
    [SerializeField] private bool keysMustBeUp = true;

    private IButtonInteractable[] items;
    private CellGridPos[] cellItems;

    private Vector2 indexPos;
    private int lastIndex = -1;
    private int index = 0;
    private int numColons;
    private bool movementDet = false;
    private bool keyAlreadyDown = false;


    private void OnEnable()
    {
        items = GetComponentsInChildren<IButtonInteractable>();
        numColons = GetComponent<GridLayoutGroup>().constraintCount;
        cellItems = new CellGridPos[items.Length];

        for (int i = 0; i < items.Length; i++)
        {
            cellItems[i] = new CellGridPos();
            cellItems[i].item = items[i];
            cellItems[i].pos = new Vector2(i % numColons, i / numColons);
        }
        if (keysMustBeUp && (Input.GetAxis("Submit") >= axisThreshold 
            || Input.GetAxis("Horizontal") >= axisThreshold || Input.GetAxis("Horizontal") <= -axisThreshold
            || Input.GetAxis("Vertical") >= axisThreshold || Input.GetAxis("Vertical") >= axisThreshold))
        {
            keyAlreadyDown = true;
        }
    }

    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        Vector2 tempPos;
        
        if (!movementDet && !keyAlreadyDown)
        {
            if (Input.GetAxis("Horizontal") >= axisThreshold) //right selected
            {
                tempPos = new Vector2(indexPos.x + 1, indexPos.y);
                OnMovementDet(tempPos);
            }
            if (Input.GetAxis("Horizontal") <= -axisThreshold) //left selected
            {
                tempPos = new Vector2(indexPos.x - 1, indexPos.y);
                OnMovementDet(tempPos);
            }
            if (Input.GetAxis("Vertical") >= axisThreshold) //up selected
            {
                tempPos = new Vector2(indexPos.x, indexPos.y - 1);
                OnMovementDet(tempPos);
            }
            if (Input.GetAxis("Vertical") <= -axisThreshold) //down selected
            {
                tempPos = new Vector2(indexPos.x, indexPos.y + 1);
                OnMovementDet(tempPos);
            }
            if (Input.GetAxis("Submit") >= axisThreshold)
            {
                movementDet = true;
                items[FindItemIndexAtPos(indexPos)].OnButtonClicked();
            }
        } else
        {
            if(Input.GetAxis("Horizontal") <= axisThreshold && Input.GetAxis("Horizontal") >= -axisThreshold
                && Input.GetAxis("Vertical") <= axisThreshold && Input.GetAxis("Vertical") >= -axisThreshold
                && Input.GetAxis("Submit") <= axisThreshold)
            {
                movementDet = false;
                keyAlreadyDown = false;
            }
        }
    }


    private CellGridPos GetItemAtPos(Vector2 Pos)
    {
        foreach (var item in cellItems)
        {
            if (item.pos == Pos)
            {
                return item;
            }
        }
        CellGridPos nullPos = new CellGridPos();
        nullPos.pos = new Vector2(-1, -1);
        return nullPos;
    }

    private int FindItemIndexAtPos(Vector2 pos)
    {
        for (int i = 0; i < cellItems.Length; i++)
        {
            if (cellItems[i].pos == pos)
            {
                return i;
            }
        }
        return -1;
    }

    private void OnMovementDet(Vector2 tempPos)
    {
        movementDet = true;
        CellGridPos tempCell;
        tempCell = GetItemAtPos(tempPos);
        if (tempCell.pos != new Vector2(-1, -1))
        {
            indexPos = tempPos;
            lastIndex = index;
            index = FindItemIndexAtPos(tempPos);
        }
        if (lastIndex != -1) cellItems[lastIndex].item.OnItemLeft();
        cellItems[index].item.OnItemHighlighted();
    }

    public void HighlightItem()
    {
        cellItems[index].item.OnItemHighlighted();
    }

    public void LeaveItem()
    {
        cellItems[index].item.OnItemLeft();
    }
}
