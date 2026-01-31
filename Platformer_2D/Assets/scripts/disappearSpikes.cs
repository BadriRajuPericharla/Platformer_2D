using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearSpikes : MonoBehaviour
{
    [SerializeField]GameObject fence;
    [SerializeField]GameObject fence1;
    [SerializeField]Animator spikes_animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spikes_animator.SetBool("spikesUp",true);
            if (fence1 != null)
            {
                spikes_animator.SetBool("spikesUp",true);
            }
            
            Debug.Log("fenceTrigered");
        }
    }
}
