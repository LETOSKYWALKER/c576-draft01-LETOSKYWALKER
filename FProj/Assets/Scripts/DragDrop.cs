using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

public class DragDrop : NetworkBehaviour
{
    private bool isDragging = false;
    public GameObject Canvas;
    public GameObject DropZone;
    private Vector2 startPosition;
    private bool isDraggable = true;
    private bool isOverDropZone = false;
    private GameObject dropZone;
    private GameObject startParent;
    public PlayerManager PlayerManager;


    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
        DropZone = GameObject.Find("DropZone");
        if (!hasAuthority)
        {
            isDraggable = false;
        }
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
        if (!isDraggable) return;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        
        isDragging = true;
    }

    public void EndDrag()
    {
        if (!isDraggable) { 
            return; 
        }
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            isDraggable = false;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<PlayerManager>();
            PlayerManager.PlayCard(gameObject);
            Debug.Log("you placed a card");

        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

}
