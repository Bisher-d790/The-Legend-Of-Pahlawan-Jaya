using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcSight : MonoBehaviour {

    public GameObject body;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Shooting!");
            body.GetComponent<Archer>().isShooting = true;
            body.GetComponent<Animator>().SetTrigger("Shoot");
            //.GetComponent<Archer>().Shoot();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Stopped Shooting!");
            body.GetComponent<Archer>().isShooting = false;
            body.GetComponent<Animator>().SetTrigger("Stand");
        }
    }
}
