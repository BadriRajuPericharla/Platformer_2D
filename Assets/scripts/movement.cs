using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    [SerializeField]float speed =10f;
    [SerializeField]float jumpForce=3f;
    [SerializeField] Animator player_animator;
    [SerializeField]GameObject deathparticles;
    [SerializeField]AudioSource audioSource;
    [SerializeField]AudioClip jump_clip;
    [SerializeField]AudioClip hit_clip;
    [SerializeField]GameObject GameOver;
    float mobileInput;
   
    bool isGrounded;
    bool facingRight=true;
    private Rigidbody2D Rb;
    void Start()
    {
        Rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jump();
        animations();
    }
    void FixedUpdate()
    {
        move();
    }
    void move()
    {
        float x=Input.GetAxis("Horizontal")+mobileInput;
        x = Mathf.Clamp(x, -1f, 1f);
        float currentSpeed=isGrounded ? speed : speed*0.9f;
        Rb.velocity=new Vector2(x*currentSpeed,Rb.velocity.y);
        if (x > 0.1f && facingRight==false)
        {
            transform.rotation=Quaternion.Euler(0f,0f,0f);
            facingRight=true;
        }
        else if (x < -0.1f && facingRight==true)
        {
            transform.rotation=Quaternion.Euler(0f,180f,0f);
            facingRight=false;
        }
    }
    

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            audioSource.PlayOneShot(jump_clip);
            isGrounded=false;
        }
    }
    void animations()
    {
        float z=Mathf.Abs(Rb.velocity.x);
        player_animator.SetBool("isRun",z>0.1f);
        player_animator.SetBool("isJump",!isGrounded);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                isGrounded=true;
                break;
            case "Spikes":
                Debug.Log("hit trap");
                die();
                GameOver.SetActive(true);
                audioSource.PlayOneShot(hit_clip);
                break;
        }
    }
    void die()
    {
        GameObject p=Instantiate(deathparticles,transform.position,Quaternion.identity);
        p.GetComponent<ParticleSystem>().Play();
        
        Destroy(gameObject);
    }
    // ================= MOBILE BUTTON FUNCTIONS =================
public void MoveLeft()
{
    mobileInput = -1f;
}

public void MoveRight()
{
    mobileInput = 1f;
}

public void StopMove()
{
    mobileInput = 0f;
}

public void MobileJump()
{
    if (isGrounded)
    {
        Rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        audioSource.PlayOneShot(jump_clip);
        isGrounded = false;
    }
}

    
}
