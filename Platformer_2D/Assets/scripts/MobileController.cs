using UnityEngine;

public class MobileController : MonoBehaviour
{
    public Transform player;      // drag Player here
    public float moveSpeed = 8f;
    public float jumpForce = 3f;

    bool moveLeft;
    bool moveRight;
    bool facingRight = true;

    void Update()
    {
        if (player == null)
            return;

        if (moveLeft)
        {
            if (facingRight)
            {
                player.rotation = Quaternion.Euler(0f, 180f, 0f);
                facingRight = false;
            }

            player.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (moveRight)
        {
            if (!facingRight)
            {
                player.rotation = Quaternion.Euler(0f, 0f, 0f);
                facingRight = true;
            }

            player.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    // BUTTON EVENTS
    public void LeftDown()  { moveLeft = true; }
    public void LeftUp()    { moveLeft = false; }

    public void RightDown() { moveRight = true; }
    public void RightUp()   { moveRight = false; }

    public void Jump()
    {
        if (player == null) return;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
