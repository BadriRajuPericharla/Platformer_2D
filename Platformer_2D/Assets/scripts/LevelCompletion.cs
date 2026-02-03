using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] GameObject levelComplete;
    [SerializeField] MonoBehaviour movement;
    [SerializeField] int keysNeeded;
    public GameObject Insufficient;

    void Start()
    {
        
    }

        void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)

    {
        if(KeyRotation.score==keysNeeded)
        {
        if (collision.gameObject.tag == "Player")
        {
            levelComplete.SetActive(true);
            movement.enabled=false;
        }
        }
        else if(KeyRotation.score!=keysNeeded) 
        {
            Insufficient.SetActive(true);
        }
    }
}
