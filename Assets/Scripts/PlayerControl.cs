using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerSub))]

public class PlayerControl : MonoBehaviour {

	[Header("Movement")]

	[SerializeField]
	private float walkSpeed = 8f;
	[SerializeField]
	private float runSpeed = 12f;
	private float currentSpeed;

	[SerializeField]
	private float lookSpeed = 5f;
	[SerializeField]
	private Slider lookSpeedSlider;

	[SerializeField]
	private float jumpSpeed = 20f;
	private bool canJump = false;
	private bool jumped = false;


	[Header("Game Objects")]
	
	[SerializeField]
	private GameObject UIController;

	[SerializeField]
	private Weapon[] weapons;

	private PlayerSub playerSub;


	/*** Init Method ***/
	public void Start () {
		UIController.GetComponent<UIControl>().cusrorLocked = true;

		playerSub = GetComponent<PlayerSub>();

		lookSpeedSlider.value = lookSpeed;
		lookSpeedSlider.onValueChanged.AddListener(delegate {UpdateLookSpeed();});
	}
	
	/*** Update Loop ***/
	void FixedUpdate () {
		Cursor.lockState = CursorLockMode.Locked;
		SetMovementSpeed();
		playerSub.Move(currentSpeed);
		playerSub.Turn(lookSpeed);
		TryJump();
		TryShoot();
	}

	void SetMovementSpeed(){
		currentSpeed = Input.GetButton("Run") ? runSpeed : walkSpeed;
	}

	void TryJump(){
		if(Input.GetButtonDown("Jump") && canJump){
			canJump = !jumped;
			jumped = true;
			playerSub.Jump(jumpSpeed);
		}
	}

	void TryShoot(){
		if(Input.GetButtonDown("Fire1")) playerSub.Shoot(weapons[0]);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "ground"){
			canJump = true;
			jumped = false;
		}
	}

	void UpdateLookSpeed(){
		lookSpeed = lookSpeedSlider.value;
	}
}