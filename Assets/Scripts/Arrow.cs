using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{

    public AudioClip HitSFX;
    public int damageAmount = 5;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player"))
        {
            CharacterController2D player = collision.gameObject.GetComponent<CharacterController2D>();
            if (player.playerCanMove)
            {

                GetComponent<AudioSource>().PlayOneShot(HitSFX);

                // stop moving
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

                // apply damage to the player
                player.ApplyDamage(damageAmount);
            }
        }
    }
}