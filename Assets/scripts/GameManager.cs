using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    [SerializeField]private movement movement;
    public Vector2 currentCheckPosition;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        currentCheckPosition = movement.transform.position;
    }
}
