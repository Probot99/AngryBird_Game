using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]

public class Monster : MonoBehaviour
{
    // only for destory Bird 
    [SerializeField] Sprite deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
     bool _hasDied;

     void OnCollisionEnter2D(Collision2D collision)
    {

        if (ShouldDieForCollision(collision))
        {
            StartCoroutine(Die());
        }
       
    }

     

    bool ShouldDieForCollision(Collision2D collision)
    {
        if ( _hasDied)
            return false;
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
        {
            return true;
        }
        if (collision.contacts[0].normal.y < -0.5)
            return true;
        return false;
    }

   IEnumerator Die()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = deadSprite;
        _particleSystem.Play();
        
        yield return new WaitForSeconds(1);
      
        gameObject.SetActive(false);
    }
}
