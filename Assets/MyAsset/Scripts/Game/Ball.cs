using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isDead = false;
    public GameManager gameManager;
    public GameObject DeadEffect;
    public AudioClip DeadSound;
    public GameObject ClearEffect;
    public AudioClip ClearSound;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            OnClear(collision);
        }
        else if(collision.gameObject.tag == "Trap")
        {
            OnDied();
        }
    }
    void OnClear(Collider2D col)
    {
        Debug.Log("Å¬¸®¾î!");
        ClearEffect.SetActive(true);
        ClearEffect.transform.position = this.transform.position;
        Destroy(col.gameObject);
        audioSource.PlayOneShot(ClearSound, 1);

        Invoke("OffClearEffect", 1);
        gameManager.NextStage();
    }
    void OffClearEffect()
    {
        ClearEffect.SetActive(false);
    }
    private void OnDied()
    {
        if (isDead == false)
        {
            Debug.Log("»ç¸Á");
            isDead = true;
            DeadEffect.SetActive(true);
            DeadEffect.transform.position = this.transform.position;
            audioSource.PlayOneShot(DeadSound, 1);
            this.GetComponent<SpriteRenderer>().enabled = false;
            VelocityZero();
            Invoke("OffDeadEffect", 1);
        }
    }
    void OffDeadEffect()
    {
        DeadEffect.SetActive(false);
        gameManager.PlayerRePosition(gameManager.stageIndex);
        this.GetComponent<SpriteRenderer>().enabled = true;
        isDead = false;
    }
    public void VelocityZero()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
