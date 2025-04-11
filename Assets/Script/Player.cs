using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce , speedMove = 5f;    
    public Transform  checkeGround;
    public LayerMask layerGround, layerTrap, layerVictory;
    public bool isGrounded, isTraped, isVictored, playerDead;    
    public SpriteRenderer playerRender;
    public GameObject refreshBTN, victoryIMG;

    private Rigidbody2D rb;
    // playerInput é uma variavel utilizada para o metodo MovimentPlayer
    //private float playerInput;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRender = GetComponent<SpriteRenderer>();
        playerDead = false;
        refreshBTN.SetActive(false);
        victoryIMG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CheckedGround();
        CheckedTrap();
        CheckedVictory();
       // MovimentPlayer();
        DeathPlayer();
        VictoryPlayer();        
    }    
    

    public void CheckedGround()
    {
        isGrounded = Physics2D.OverlapCapsule(checkeGround.position, new Vector2(1f, 0.6f), CapsuleDirection2D.Horizontal, 0, layerGround);
    }

    public void CheckedTrap()
    {
        isTraped = Physics2D.OverlapCapsule(checkeGround.position, new Vector2(0.1f, 0.5f), CapsuleDirection2D.Horizontal, 0, layerTrap);
    }

    public void CheckedVictory()
    {
        isVictored = Physics2D.OverlapCapsule(checkeGround.position, new Vector2(0.1f, 0.5f), CapsuleDirection2D.Horizontal, 0, layerVictory);
    }

    //Metodo para realizar moviemtação do Player pelo teclado.
    /*public void MovimentPlayer()
    {
        playerInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(playerInput * speedMove, rb.velocity.y);
    }*/

    public void MoveLeftPlayer()
    {
        rb.velocity = new Vector2(-0.7f * speedMove, rb.velocity.y);
    }

    public void MoveRigthtPlayer()
    {
        rb.velocity = new Vector2(0.7f * speedMove , rb.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
     

    public void DeathPlayer()
    {
        if (isTraped)
        {
            playerRender.enabled = false;            
            Time.timeScale = 0;            
            refreshBTN.SetActive(true);            
        }
    }

    public void VictoryPlayer()
    {
        if (isVictored)
        {
            victoryIMG.SetActive(true);
            Time.timeScale = 0;           

        }
    }

}
