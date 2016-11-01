using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	public Transform checkGround;
	public float checkgroundRadius;
	// This will be what the ground is assigned to
	public LayerMask whatisGround;
	public bool amGrounded;
	public bool doublejumped;

	// Use this for initialization
	void Start () 
	{
		amGrounded = Physics2D.OverlapCircle (checkGround.position, checkgroundRadius, whatisGround);
			
	}

	void FixedUpdate() 
	{
		
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.W) && amGrounded) 
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			amGrounded = false;
			Debug.Log (amGrounded);
		} 
		// If the Player is in the air, player cannot double jump
		if(GetComponent<Rigidbody2D> ().velocity.y == 0) 
		{
			amGrounded = true;
		}

		if (Input.GetKey(KeyCode.D)) 
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		if (Input.GetKey(KeyCode.A))  
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (- moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		/* Stopping the sliding */
		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) )
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
		}


	}
}