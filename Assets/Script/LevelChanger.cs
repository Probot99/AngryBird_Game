using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
      public Monster[]  _monsters;
     [SerializeField] string _nextLevelName;

    void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (MonstersAreAllDead())
            
            GoToNextLevel();

    }

     void GoToNextLevel()
    {
        Debug.Log("Go To Next Level" + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

      bool MonstersAreAllDead()
    {
         foreach(var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }
        return true;
    }
}
