using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject zoomCard;

    public void Awake()
    {
        Canvas = GameObject.Find("Canvas");
    }

    public void OnHoverEnter()
    {
        zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 125), Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.layer = LayerMask.NameToLayer("Zoom");
        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(132, 176);
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard);
    }
}
