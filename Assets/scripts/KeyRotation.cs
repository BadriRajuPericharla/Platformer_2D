using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyRotation : MonoBehaviour
{
   [SerializeField]float speed=2f;
   [SerializeField]AudioSource audioSource;
   [SerializeField]AudioClip key;

    [SerializeField]TextMeshProUGUI scoreTxt;
    public static int score=0;
    void Awake()
    {
        score=0;
    }
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0f,0f,speed*Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(key);
            score++;
            scoreTxt.text=score.ToString();
            Destroy(gameObject);
        }
    
        
    }
}
