// ************************************************************************ 
// File Name:   Player.cs 
// Purpose:     Contains methods governing a player  
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
// Class: NetworkManager 
// ************************************************************************ 
public class NetworkManager : MonoBehaviour 
{
	
	
    // ********************************************************************
    // Exposed Data Members 
    // ********************************************************************
	
	// Button details. Button x will be centered.
	public int m_buttonWidth, m_buttonHeight, m_buttonPadding, m_buttonY;
	
	// Host list details. Host list will be centered.
	public int m_hostListWidth, m_hostListHeight, m_hostListPadding,
		m_hostListY, m_numHostsListed;
	
	// Max players allowed in the server
	public int m_maxNumPlayers;
	
	// Default port
	public int m_defaultPort;
	
	// Unity-unique game ID
	public string m_unityGameID;
	
	// Default game instance name
	public string m_defaultGameName;
	
	// Default game instance comment
	public string m_defaultGameComment;
	
	// Configure host list request parameters
	public bool m_autoRefreshHostList;
	public float m_hostListRefreshTime;
	
	
    // ********************************************************************
    // Private Data Members 
    // ********************************************************************
	private HostData[] m_hostList = new HostData[0];
	private float m_timeSinceLastRefresh = 0.0f;
	
	
    // ********************************************************************
    // Function:	Start()
    // Purpose:     Run when new instance of the object is created.
    // ********************************************************************
	void Start () 
	{
		
	}
	
	
    // ********************************************************************
    // Function:	Update()
    // Purpose:		Called once per frame.
    // ********************************************************************
	void Update () 
	{
		// Send a request for a host list update if it is time
		m_timeSinceLastRefresh += Time.deltaTime;
		if (m_autoRefreshHostList && m_timeSinceLastRefresh > m_hostListRefreshTime)
		{
			Debug.Log("Automatically refreshing host list.");
			m_timeSinceLastRefresh = 0.0f;
			RefreshHostList();
		}
	}
	
	
    // ********************************************************************
    // Function:	OnGUI()
    // Purpose:		Refreshes GUI, can be called multiple times per frame.
    // ********************************************************************
	void OnGUI () 
	{
		
		// Button: Host Game
		if (GUI.Button (new Rect (
			Screen.width/2 - (m_buttonWidth*3/2 + m_buttonPadding), 
			m_buttonY, m_buttonWidth, m_buttonHeight), "Host Game")) 
		{
			Debug.Log("\"Host Game\" clicked");
			StartHost();
		}
		
		// Button: Refresh Host List
		if (GUI.Button (new Rect (
			Screen.width/2 - (m_buttonWidth/2), 
			m_buttonY, m_buttonWidth, m_buttonHeight), "Refresh")) 
		{
			Debug.Log("\"Refresh\" clicked");
			RefreshHostList();
		}
		
		// Button: Quit
		if (GUI.Button (new Rect (
			Screen.width/2 + (m_buttonWidth/2 + m_buttonPadding), 
			m_buttonY, m_buttonWidth, m_buttonHeight), "Quit")) 
		{
			Debug.Log("\"Quit\" clicked");
			Application.Quit();
		}
		
		// Buttons: Host List
		// TODO: Modify to allow scrolling ++++++++++++++++++++++++++++++++
		// TODO: Display more info about each game ++++++++++++++++++++++++
		// TODO: Password support +++++++++++++++++++++++++++++++++++++++++
		for (int i = 0; i < m_numHostsListed; ++i)
		{
			// Get host name from list
			string hostName, hostComment;
			if (i < m_hostList.Length) 
			{
				hostName = m_hostList[i].gameName;
				hostComment = m_hostList[i].comment;
			}
			else 
			{
				hostName = "";
				hostComment = "";
			}
			
			// Button: Host
			if (GUI.Button (new Rect (
				Screen.width/2 - m_hostListWidth/2, 
				m_hostListY + i * (m_hostListHeight + m_hostListPadding), 
				m_hostListWidth, m_hostListHeight), hostName+"\n"+hostComment)) 
			{
				Debug.Log("Host \""+hostName+"\" clicked");
				if (i < m_hostList.Length)
				{
					ConnectToHost(m_hostList[i]);
				}
			}
		}
		
	}
	
	
    // ********************************************************************
    // Function:	OnServerInitialized()
    // Purpose:		Called if this game is initialized as a server.
    // ********************************************************************
	void OnServerInitialized () 
	{
		Debug.Log("Server initialized.");
	}
	
	
    // ********************************************************************
    // Function:	OnMasterServerEvent()
    // Purpose:		Handles server events.
    // ********************************************************************
	void OnMasterServerEvent (MasterServerEvent serverEvent) 
	{
		Debug.Log("MasterServerEvent received: "+serverEvent);

		switch (serverEvent)
		{
		    case MasterServerEvent.HostListReceived: 
		        Debug.Log("Received Host List.");
				ProcessHostList();
		        break;
		    case MasterServerEvent.RegistrationFailedGameName:
		        Debug.Log("Registration of host failed due to empty game name.");
				// TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case MasterServerEvent.RegistrationFailedGameType:
		        Debug.Log("Registration of host failed due to empty game type.");
				// TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case MasterServerEvent.RegistrationFailedNoServer:
				// This should not occur, if it does it is not due to player error
		        Debug.Log("Registration of host failed due to no server running.");
		        break;
		    case MasterServerEvent.RegistrationSucceeded:
		        Debug.Log("Registration of host succeeded.");
				// TODO: Move to lobby screen +++++++++++++++++++++++++++++
		        break;
		    default:
		        Debug.Log("Unknown master host event.");
		        break;
		}
		
	}
	
	
    // ********************************************************************
    // Function:	StartHost()
    // Purpose:     Creates a server and moves to the game lobby
    // ********************************************************************
	private void StartHost()
	{
		// TODO: Customize name, comment, etc +++++++++++++++++++++++++++++
		// TODO: Password support +++++++++++++++++++++++++++++++++++++++++
		string gameName = m_defaultGameName;
		string gameComment = m_defaultGameComment;
		int port = m_defaultPort;
		int numPlayers = m_maxNumPlayers;
		
		// Set up as a server
		Network.InitializeServer(numPlayers,port,!Network.HavePublicAddress());
		
		// Register server with Unity master server
		MasterServer.RegisterHost(m_unityGameID,gameName,gameComment);
	}
	
	
    // ********************************************************************
    // Function:	RefreshHostList()
    // Purpose:     Requests a refresh of the server list
    // ********************************************************************
	private void RefreshHostList()
	{
		// Request a refreshed host list from the server
		MasterServer.RequestHostList(m_unityGameID);
	}
	
	
    // ********************************************************************
    // Function:	ProcessHostList()
    // Purpose:     Processes the returned host list from the Master Server
    // ********************************************************************
	private void ProcessHostList()
	{
		m_hostList = MasterServer.PollHostList();
	}
	
	
    // ********************************************************************
    // Function:	ConnectToHost()
    // Purpose:     Attempts to connect to a host and processes any errors
	// Parameters:	HostData host - the host to connect to
    // ********************************************************************
	private void ConnectToHost(HostData host)
	{
		NetworkConnectionError error = Network.Connect(host);
		
		switch (error)
		{
		    case NetworkConnectionError.AlreadyConnectedToAnotherServer: 
				// This should not occur, if it does it is not due to player error
		        Debug.Log("Unable to connect to host: Already connected to another server.");
		        break;
		    case NetworkConnectionError.AlreadyConnectedToServer:
				// This should not occur, if it does it is not due to player error
		        Debug.Log("Unable to connect to host: Already connected to this server.");
		        break;
		    case NetworkConnectionError.ConnectionBanned:
		        Debug.Log("Unable to connect to host: You have been banned from the system you are attempting to connect to.");
				// TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case NetworkConnectionError.ConnectionFailed:
		        Debug.Log("Unable to connect to host: Check your internet connection.");
				// TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case NetworkConnectionError.CreateSocketOrThreadFailure:
		        Debug.Log("Unable to connect to host: Internal error while attempting to initialize network interface. Socket possibly already in use.");
				// TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case NetworkConnectionError.EmptyConnectTarget:
				// This should not occur, if it does it is not due to player error
		        Debug.Log("Unable to connect to host: Empty target host");
		        break;
		    case NetworkConnectionError.IncorrectParameters:
				// This should not occur, if it does it is not due to player error
		        Debug.Log("Unable to connect to host: Incorrect parameters given to Network.Connect() function.");
		        break;
		    case NetworkConnectionError.InternalDirectConnectFailed:
		        Debug.Log("Unable to connect to host: Client could not connect internally to same network NAT enabled server.");
		        // TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case NetworkConnectionError.InvalidPassword:
		        Debug.Log("Unable to connect to host: Invalid password.");
		        // TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case NetworkConnectionError.NATPunchthroughFailed:
		        Debug.Log("Unable to connect to host: NAT punchthrough attempt has failed. The cause could be a too restrictive NAT implementation on either endpoints.");
		        // TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case NetworkConnectionError.NATTargetConnectionLost:
		        Debug.Log("Unable to connect to host: Connection lost while attempting to connect to NAT target.");
		        // TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case NetworkConnectionError.NATTargetNotConnected:
		        Debug.Log("Unable to connect to host: The NAT target you are trying to connect to is not connected to the facilitator server.");
		        // TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case NetworkConnectionError.NoError:
		        Debug.Log("Connected to host.");
		        // TODO: Move to lobby screen +++++++++++++++++++++++++++++
		        break;
		    case NetworkConnectionError.RSAPublicKeyMismatch:
		        Debug.Log("Unable to connect to host: RSA public key does not match host.");
		        // TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    case NetworkConnectionError.TooManyConnectedPlayers:
		        Debug.Log("Unable to connect to host: Host is already at max player limit.");
		        // TODO: Display error to player ++++++++++++++++++++++++++
		        break;
		    default:
		        Debug.Log("Unknown network connection error.");
		        break;
		}
		
	}
	
}
