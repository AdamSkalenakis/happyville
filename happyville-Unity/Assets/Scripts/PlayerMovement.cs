// ************************************************************************ 
// File Name:   PlayerMovement.cs 
// Purpose:     Contains player movement methods and  
// Project:     happyville - social game involving people and monsters 
//				and their interactions.
// Author:      Sarah Herzog  
// Copyright:   2013 Precarious Productions
// ************************************************************************ 


// ************************************************************************ 
// Imports 
// ************************************************************************
using UnityEngine;
using System.Collections;


// ************************************************************************ 
// Class: PlayerMovement 
// ************************************************************************ 
public class PlayerMovement : MonoBehaviour {
      
	
    // ********************************************************************
    // Exposed Data Members 
    // ********************************************************************
    public float m_maxLinearSpeed;
	public float m_maxAngularSpeed;

	
    // ********************************************************************
    // Private Data Members 
    // ********************************************************************
	private float m_currentLinearSpeed;
	private float m_currentAngularSpeed;
	private float m_facing;
	
	
    // ********************************************************************
    // Function:	Start()
    // Purpose:     Run when new instance of the object is created.
    // ********************************************************************
	void Start () {
		
		// Set initial speeds to max values
		m_currentLinearSpeed = m_maxLinearSpeed;
		m_currentAngularSpeed = m_maxAngularSpeed;
	}
	
	
    // ********************************************************************
    // Function:	Update()
    // Purpose:		Called once per frame.
    // ********************************************************************
	void Update () {
		ProcessMovement();
		ProcessFacing();
	}
	
	
    // ********************************************************************
    // Function:	ProcessMovement()
    // Purpose:		Takes player input and determines movement.
    // ********************************************************************
	private void ProcessMovement()
	{
		// Define local variables
		Vector2 moveDirection, moveVelocity;
		
		// Get magnitude 1 direction from input
		moveDirection = new Vector2(
			Input.GetAxis("Horizontal"), 
			Input.GetAxis("Vertical")
		);
		moveDirection.Normalize();
		
		// Scale to speed and set velocity
		moveVelocity = moveDirection * m_currentLinearSpeed;
		rigidbody.velocity = moveVelocity;
	}
	
	
    // ********************************************************************
    // Function:	ProcessFacing()
    // Purpose:		Takes player input and determines facing.
    // ********************************************************************
	private void ProcessFacing()
	{
		// Define local variables
		Vector2 moveDirection;
		float targetAngle, angleDistanceLeft, angleDistanceRight, angleDistance, angleDirection;
		
		// Get target based on movement
		moveDirection = new Vector2(
			Input.GetAxis("Horizontal"), 
			Input.GetAxis("Vertical")
		);
		moveDirection.Normalize();
		targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x)*(180.0f/Mathf.PI);
		if (targetAngle < 0 ) targetAngle += 360.0f;
		if (targetAngle > 360.0f ) targetAngle -= 360.0f;
		
		// TODO: Get target based on left-click
		
		// Turn toward target
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) 
		{
			// Determine angleDirection and angleDistance based on targetAngle and current m_facing
			angleDistanceLeft = targetAngle - m_facing;
			if (angleDistanceLeft < 0 ) angleDistanceLeft += 360.0f;
			angleDistanceRight = m_facing - targetAngle;
			if (angleDistanceRight < 0 ) angleDistanceRight += 360.0f;
			if (angleDistanceLeft < angleDistanceRight)
			{
				angleDistance = angleDistanceLeft;
				angleDirection = 1.0f; // Turn counter-clockwise
			}
			else
			{
				angleDistance = angleDistanceRight;
				angleDirection = -1.0f; // Turn clockwise
			}
			// If the increment would take us past targetAngle, just set as targetAngle
			if ( m_currentAngularSpeed > angleDistance )
				m_facing = targetAngle;
			// Otherwise, increment.
			else
				m_facing += angleDirection * m_currentAngularSpeed;
			
		}
		if (m_facing < 0 ) m_facing += 360.0f;
		if (m_facing > 360.0f ) m_facing -= 360.0f;
		gameObject.GetComponent<OTSprite>().rotation = m_facing;
        
	}
}
