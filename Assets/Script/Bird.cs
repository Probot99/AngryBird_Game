using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float maxDragDistance = 2;
    [SerializeField] float _launchForce = 500;
    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer spriteRenderer;

     void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    // Start is called before the first frame update
    void Start()
    {    // star  position setup 
        _startPosition = _rigidbody2D.position;

        GetComponent<Rigidbody2D>().isKinematic = true;
        
    }


    // change color Bird if we touch 
     void OnMouseDown()
    {

        spriteRenderer.color = Color.red;
    }
    // recolor first stage
     void OnMouseUp()
    {
        Vector2 currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition;

        direction.Normalize();
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);
        spriteRenderer.color = Color.white; 
    }
    // motion of Bird 
      void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector2 desirePosition = mousePosition;
        float distance = Vector2.Distance(desirePosition, _startPosition);
        Debug.Log($"Distance:{distance}");
        if (distance > maxDragDistance)
        {
            Vector2 direcation = desirePosition - _startPosition;
            direcation.Normalize();
            desirePosition = _startPosition + (direcation * maxDragDistance);
            Debug.Log("Adjusted Distance: " + Vector3.Distance( desirePosition, _startPosition));
        }
        if (desirePosition.x > _startPosition.x)
            desirePosition.x = _startPosition.x;

        _rigidbody2D.position = desirePosition;
      // transform.position = mousePosition;
       // transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // collision method
     void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(RestAfterDealy());
        Debug.Log( collision.collider.gameObject.name);
         
    }

    IEnumerator RestAfterDealy()
    {
        yield return new  WaitForSeconds(2);
        _rigidbody2D.position = _startPosition;

        GetComponent<Rigidbody2D>().isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;

    }
}
