using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    public GameObject Canvas;
    private Vector2 startPosition;
    private bool isOverDropZone = false;
    private GameObject dropZone;
    private GameObject startParent;


    private void Awake()
    {
        Canvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            Debug.Log("you placed a card");

        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

}
