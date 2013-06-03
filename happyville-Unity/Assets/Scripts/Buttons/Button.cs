// ************************************************************************ 
// File Name:   Button.cs 
// Purpose:     Contains methods for using a button with Orthello2D sprites  
// Project:     happyville - social game involving people and monsters 
//				and their interactions.
// Author:      Sarah Herzog  
// Copyright:   2013 Precarious Productions
// ************************************************************************ 
// TODO:
// 	- Tooltips
// ************************************************************************ 


// ************************************************************************ 
// Imports 
// ************************************************************************
using UnityEngine;
using System.Collections;


// ************************************************************************ 
// Class: Button 
// ************************************************************************ 
[RequireComponent (typeof (OTSprite))]
public class Button : MonoBehaviour 
{
	
	
    // ********************************************************************
    // Exposed Data Members 
    // ********************************************************************
	public bool m_enabled = true;
	
	// Textures and display
	public Texture m_normal;
	public Texture m_rollover;
	public Texture m_clicked;
	public Texture m_disabled;
	public float m_clickOffset;
	
	// Text
	public string m_text;
	public Color m_fontColorNormal;
	public Color m_fontColorRollover;
	public Color m_fontColorClicked;
	public Color m_fontColorDisabled;
	public Color m_fontColorCurrent;
	
	
    // ********************************************************************
    // Private Data Members 
    // ********************************************************************
	private enum ButtonState 
	{ 
		NORMAL, ROLLOVER, CLICKED, DISABLED 
	};
	private ButtonState m_state;
	private OTSprite m_sprite;
	private float m_yNormal;
	private float m_yClicked;
	private GameObject m_textObject;
	private OTTextSprite m_textSprite;
	
	
    // ********************************************************************
    // Function:	Start()
    // Purpose:     Run when new instance of the object is created.
    // ********************************************************************
	void Start () 
	{
		// Find OTSprite
		m_sprite = GetComponent<OTSprite>();
		
		// Enable OTSprite for clicking and rollover
		m_sprite.registerInput = true;
     	m_sprite.onInput = OnInput;
     	m_sprite.onMouseEnterOT = OnEnter;
     	m_sprite.onMouseExitOT = OnExit;
		
		// Set up y coordintes
		m_yNormal = m_sprite.position.y;
		m_yClicked = m_yNormal - m_clickOffset;
		
		// Set up enabled/disabled
		if (m_enabled) EnableButton ();
		else DisableButton();
	}
	
	
    // ********************************************************************
    // Function:	DisableButton()
    // Purpose:		Called when Button is disabled
    // ********************************************************************
	void DisableButton()
	{
		m_sprite.image = m_disabled;
		m_state = ButtonState.DISABLED;
		m_fontColorCurrent = m_fontColorDisabled;
		m_enabled = false;
	}
	
	
    // ********************************************************************
    // Function:	EnableButton()
    // Purpose:		Called when Button is enabled
    // ********************************************************************
	void EnableButton()
	{
		m_sprite.image = m_normal;
		m_state = ButtonState.NORMAL;
		m_fontColorCurrent = m_fontColorNormal;
		m_enabled = true;
	}
	
	
    // ********************************************************************
    // Function:	OnInput()
    // Purpose:		Called when OTSprite registers input
    // ********************************************************************
	void OnInput(OTObject owner)
	{
		if (!m_enabled) return;
		
		if (Input.GetMouseButton(0))
		{
			m_sprite.position = new Vector2(m_sprite.position.x,m_yClicked);
			m_sprite.image = m_clicked;
			m_state = ButtonState.CLICKED;
			m_fontColorCurrent = m_fontColorClicked;
		}
		else if (!Input.GetMouseButton(0) && m_state == ButtonState.CLICKED)
		// Button has just been released on this button
		{
			m_sprite.position = new Vector2(m_sprite.position.x,m_yNormal);
			m_sprite.image = m_rollover;
			m_state = ButtonState.ROLLOVER;
			m_fontColorCurrent = m_fontColorRollover;
			OnClick();
		}
	}
	
	
    // ********************************************************************
    // Function:	OnEnter()
    // Purpose:		Called when OTSprite registers mouse entering
    // ********************************************************************
	void OnEnter(OTObject owner)
	{
		if (!m_enabled) return;
		
		if (!Input.GetMouseButton(0)) 
		{
			m_sprite.image = m_rollover;
			m_state = ButtonState.ROLLOVER;
			m_fontColorCurrent = m_fontColorRollover;
		}
		else if (Input.GetMouseButton(0)) 
		{
			m_sprite.image = m_clicked;
			m_state = ButtonState.CLICKED;
			m_fontColorCurrent = m_fontColorClicked;
			m_sprite.position = new Vector2(m_sprite.position.x,m_yClicked);
		}
	}
	
	
    // ********************************************************************
    // Function:	OnExit()
    // Purpose:		Called when OTSprite registers mouse exiting
    // ********************************************************************
	void OnExit(OTObject owner)
	{
		if (!m_enabled) return;
		
		m_sprite.image = m_normal;
		m_state = ButtonState.NORMAL;
		m_fontColorCurrent = m_fontColorNormal;
		m_sprite.position = new Vector2(m_sprite.position.x,m_yNormal);
	}
	
	
    // ********************************************************************
    // Function:	OnClick()
    // Purpose:		Called when the button is clicked
    // ********************************************************************
	protected virtual void OnClick()
	{
		if (!m_enabled) return;
	}
}
