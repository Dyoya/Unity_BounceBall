using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BounceBall : MonoBehaviour
{
    public AudioClip BounceSound;
    public AudioClip LongJumpSound;
    public AudioClip DashSound;
    bool isJumping = true;
    bool isMoveTile = false;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && isMoveTile)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            isMoveTile= false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Jump(col);
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        Jump(col);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Á¡ÇÁ Áß");
        isJumping = true;
    }
    private void Jump(Collision2D col)
    {
        if (isJumping)
        {
            isJumping = false;
            if (col.gameObject.tag == "Tile" && col.transform.position.y + 0.725 <= this.transform.position.y)
            {
                Tile_Jump();
            }
            else if (col.gameObject.tag == "JumpTile" && col.transform.position.y + 0.725 <= this.transform.position.y)
            {
                JumpTile_Jump();
            }
            else if (col.gameObject.tag == "RightMoveTile" && col.transform.position.y + 0.725 <= this.transform.position.y)
            {
                RightMoveTile(col);
            }
            else if (col.gameObject.tag == "LeftMoveTile" && col.transform.position.y + 0.725 <= this.transform.position.y)
            {
                LeftMoveTile(col);
            }
            else
            {
                if (isMoveTile)
                {
                    this.GetComponent<Rigidbody2D>().gravityScale = 1;
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    isMoveTile = false;
                }
                else
                {
                    Debug.Log("¿¡·¯");
                }
            }
        }
    }
    private void Tile_Jump()
    {
        Debug.Log("±âº» Á¡ÇÁ");
        audioSource.PlayOneShot(BounceSound, 0.5f);
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

    }
    private void JumpTile_Jump()
    {
        Debug.Log("½´ÆÛ Á¡ÇÁ");
        audioSource.PlayOneShot(LongJumpSound, 0.5f);
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8), ForceMode2D.Impulse);

    }
    private void RightMoveTile(Collision2D col)
    {
        Debug.Log("¿À¸¥ÂÊ Âß");
        audioSource.PlayOneShot(DashSound, 0.8f);
        isMoveTile = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.transform.position = new Vector2(col.transform.position.x + 0.6f, col.transform.position.y);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(8, 0);
    }
    private void LeftMoveTile(Collision2D col)
    {
        Debug.Log("¿ÞÂÊ Âß");
        audioSource.PlayOneShot(DashSound, 0.8f);
        isMoveTile = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.transform.position = new Vector2(col.transform.position.x - 0.6f, col.transform.position.y);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-8, 0);
    }
}
