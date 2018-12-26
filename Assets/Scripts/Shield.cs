using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    bool isTaken = false;

    //when collided with player, wear on player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.transform.SetParent(other.transform);
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.transform.localPosition = new Vector3(0.25f, -0.1f, 0f);
            this.transform.localScale = new Vector3(0.5f, 1f, 1f);
            this.GetComponentInParent<CharacterController2D>().playerHealth = 30;
            isTaken = true;

        }
    }

    private void Update()
    {
        if (isTaken)
        {
            if (GetComponentInParent<CharacterController2D>().playerHealth <= 10)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
