// ************************************************************************ 
// File Name:   ButtonScreenChange.cs 
// Purpose:     Button that changes between screens  
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
// Class: ButtonScreenChange 
// ************************************************************************ 
[RequireComponent (typeof (OTSprite))]
public class ButtonScreenChange : Button 
{
	
    // ********************************************************************
    // Exposed Data Members 
    // ********************************************************************
	public string m_targetScene;
	
	
    // ********************************************************************
    // Function:	OnClick()
    // Purpose:		Called when the button is clicked
    // ********************************************************************
	protected override void OnClick()
	{
		if (!m_enabled) return;
		
		Debug.Log("Loading scene: "+m_targetScene);
		Application.LoadLevel(m_targetScene);
	}
	
}
