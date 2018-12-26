using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{

    public bool taken = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Player") && (!taken) && (other.gameObject.GetComponent<CharacterController2D>().playerCanMove))
        {
            // mark as taken so doesn't get taken multiple times
            taken = true;

            this.gameObject.GetComponent<Animator>().SetBool("Checked", true);

            // do the player collect coin thing
            other.GetComponent<CharacterController2D>().Checkpoint(this.transform.position);

            // destroy the coin
            DestroyObject(this.gameObject.GetComponent<Collider2D>());

        }
    }

}
