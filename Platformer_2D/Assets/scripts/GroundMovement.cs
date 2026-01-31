using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField]float speed =1f;
    [SerializeField]GameObject horizontalMovement;
    [SerializeField]GameObject verticalMovement;
    int direction=1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        if (horizontalMovement != null)
        {
            horizontalMovement.transform.Translate(Vector2.right*speed*direction *Time.deltaTime);
        }
        if (verticalMovement != null)
        {
            verticalMovement.transform.Translate(Vector2.up*speed*direction *Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            
            direction*=-1;
        }
    }

}
