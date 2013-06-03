// ************************************************************************ 
// File Name:   ButtonQuit.cs 
// Purpose:     Button that quits the application  
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
// Class: ButtonQuit 
// ************************************************************************ 
[RequireComponent (typeof (OTSprite))]
public class ButtonQuit : Button 
{
	
    // ********************************************************************
    // Function:	OnClick()
    // Purpose:		Called when the button is clicked
    // ********************************************************************
	protected override void OnClick()
	{
		if (!m_enabled) return;
		
		Application.Quit();
	}
	
}
