using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerSub : MonoBehaviour {

	[SerializeField]
	private GameObject cam;

	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	public void Move(float speed){
		float MoveH = Input.GetAxisRaw("Horizontal");
		float MoveV = Input.GetAxisRaw("Vertical");

		Vector3 movmement = new Vector3(MoveH, 0f, MoveV);
		movmement = movmement.normalized * speed * Time.deltaTime;

		movmement = transform.rotation * movmement;

		rb.MovePosition(rb.position + movmement);
	}

	public void Turn(float speed){
		float MouseH = Input.GetAxisRaw("Mouse X");
		float MouseV = Input.GetAxisRaw("Mouse Y");

		transform.Rotate(0f, MouseH * speed, 0f);
		cam.transform.Rotate(-MouseV * speed, 0f, 0f);
	}

	public void Jump(float speed){
		rb.velocity = Vector3.up * speed;
	}

	public void Shoot(Weapon weapon){
		RaycastHit hit;
		if(!Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range)) return;
		if(hit.collider.gameObject.layer != LayerMask.NameToLayer("remotePlayer")) return;

		print("Hit a player");
	}

}