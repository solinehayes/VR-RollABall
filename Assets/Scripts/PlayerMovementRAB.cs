﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovementRAB : MonoBehaviour
{
    public float speed = 0;
    private int count =0;

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public TextMeshProUGUI countText;
	public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);
    }


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("PositiveCollectible")) 
        {
            other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
        }
        if (other.gameObject.CompareTag("NegativeCollectible")) 
        {
            other.gameObject.SetActive(false);
			count = count - 1;
			SetCountText ();
        }
    }
    void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 3) 
		{
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
		}
	}

}