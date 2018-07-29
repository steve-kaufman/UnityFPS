using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour {

	[SerializeField]
	private GameObject[] canvases;

	[Header("Pause Menu")]
	[SerializeField]
	private Behaviour[] disabledWhenPaused;

	[System.NonSerialized]
	public bool cusrorLocked = false;


	private GameObject activeCanvas;

	

	// Use this for initialization
	public void Start () {
		SetActiveCanvas("Cursor");
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetButtonDown("Cancel")){
			if(activeCanvas == GetCanvas("Cursor")) Pause();
			else Resume();
		}

		if(cusrorLocked) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	public void Pause(){
		SetActiveCanvas("Menu_default");
		cusrorLocked = false;
		foreach (Behaviour component in disabledWhenPaused){
			component.enabled = false;
		}
	}

	public void Resume(){
		SetActiveCanvas("Cursor");
		cusrorLocked = true;
		foreach (Behaviour component in disabledWhenPaused){
			component.enabled = true;
		}
	}

	public void SetActiveCanvas(string name){
		foreach (GameObject canvas in canvases){
			if(canvas.name == name){
				canvas.SetActive(true);
				activeCanvas = canvas;
			}
			else canvas.SetActive(false);
		}
	}

	GameObject GetCanvas(string name){
		foreach (GameObject canvas in canvases){
			if(canvas.name == name) return canvas;
		}
		return null;
	}
}