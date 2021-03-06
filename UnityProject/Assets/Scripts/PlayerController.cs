﻿using UnityEngine;
using System.Collections;

//script from unity tutorials, used to make the ball move!

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;

	void Start()
	{
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Pickup") 
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();	
		if (count == 10)
			winText.text = "You Win";
	}
}
