using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	[SerializeField]
	private Behaviour[] componentsToDisable;

	[SerializeField]
	private GameObject[] childrenToDisable;

	void Start(){
		if(!isLocalPlayer){
			gameObject.layer = LayerMask.NameToLayer("remotePlayer");
			disableComponents();
			disableChildren();
		}
		else Camera.main.gameObject.SetActive(false);
	}

	void disableComponents(){
		foreach (Behaviour component in componentsToDisable){
			component.enabled = false;
		}
	}
	
	void disableChildren(){
		foreach (GameObject child in childrenToDisable){
			child.SetActive(false);
		}
	}

}
