using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour 
{
    public AudioClip deathClip;
    public float jumpForce = 700f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigidBody;
    private Animator animator;
    private AudioSource playerAudio;


    private void Start() 
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        GFunc.Assert(playerRigidBody != null);
        GFunc.Assert(animator != null);
        GFunc.Assert(playerAudio != null);
    }




    private void Update() 
    {
        if (isDead == true)
        {
            return;    
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidBody.velocity = Vector2.zero;
            playerRigidBody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }

        else if (Input.GetMouseButtonUp(0) && playerRigidBody.velocity.y > 0)
        {
            playerRigidBody.velocity = playerRigidBody.velocity * 0.5f;   
        }

        animator.SetBool("Grounded", isGrounded);
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidBody.velocity = Vector2.zero;
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" && !isDead)
        {
            Die();    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}