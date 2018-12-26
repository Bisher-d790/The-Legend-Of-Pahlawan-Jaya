using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {

	public int Value = 20;
	public bool taken = false;

	// if the player touches the coin, it has not already been taken, and the player can move (not dead or victory)
	// then take the coin
	void OnTriggerEnter2D (Collider2D other)
	{
		if ((other.tag == "Player" ) && (!taken) && (other.gameObject.GetComponent<CharacterController2D>().playerCanMove))
		{
			// mark as taken so doesn't get taken multiple times
			taken=true;

			this.gameObject.GetComponent<Animator> ().SetBool ("isTaken", true);

			// do the player collect coin thing
			other.gameObject.GetComponent<CharacterController2D>().CollectTreasure(Value);

			// destroy the coin
			DestroyObject(this.gameObject.GetComponent<Collider2D>());
		}
	}

}
