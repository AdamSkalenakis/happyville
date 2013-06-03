// ************************************************************************ 
// File Name:   ButtonText.cs 
// Purpose:     Syncs a button text with it's parent button  
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
// Class: ButtonText 
// ************************************************************************ 
[RequireComponent (typeof (OTTextSprite))]
[ExecuteInEditMode]
public class ButtonText : MonoBehaviour 
{
	
    // ********************************************************************
    // Private Data Members 
    // ********************************************************************
	public Button m_parentButton;
	public OTTextSprite m_textSprite;
	
	
    // ********************************************************************
    // Function:	Start()
    // Purpose:     Run when new instance of the object is created.
    // ********************************************************************
	void Start () 
	{
		// Get parent button
		m_parentButton = transform.parent.GetComponent<Button>();
		
		// Get text sprite
		m_textSprite = GetComponent<OTTextSprite>();
	}
	
	
    // ********************************************************************
    // Function:	Update()
    // Purpose:		Called once per frame, on on scene change in edit mode.
    // ********************************************************************
	void Update () 
	{
		m_textSprite.text = m_parentButton.m_text;
		m_textSprite.tintColor = m_parentButton.m_fontColorCurrent;
	}
	
	
}