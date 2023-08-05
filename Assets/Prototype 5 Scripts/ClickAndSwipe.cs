using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class ClickAndSwipe : MonoBehaviour
{
    private GameHandeler gameHandeler;
    private Camera cam;
    private Vector3 mousePosition;
    private TrailRenderer trail;
    private BoxCollider coll;

    public bool swipeing = false;

    private void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        coll = GetComponent<BoxCollider>();
        trail.enabled=false;
        coll.enabled = false;

        gameHandeler = GameObject.Find("Game Handeler").GetComponent<GameHandeler>();
    }
    private void UpdateMousePosition()
    {
        mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePosition;
    }
    private void UpdateComponent()
    {
        trail.enabled = swipeing;
        coll.enabled = swipeing;
    }
    private void Update()
    {
        if(gameHandeler.gameIsActive&&gameHandeler.gameOver==false&&gameHandeler.paused==false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                swipeing = true;
                UpdateComponent();
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            swipeing = false;
            UpdateComponent();
        }
        if(swipeing)
        {
            UpdateMousePosition();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTheTarget();
        }
    }
   
}
