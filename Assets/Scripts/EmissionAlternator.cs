using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionAlternator : MonoBehaviour {
	
	[SerializeField]
	private Color color1;
	[SerializeField]
	private Color color2;

	[SerializeField]
	private float alternateSpeed = 2f;

	private Color currentColor;


	private Material mat;

	void Start(){
		mat = GetComponent<Renderer>().material;
	}

	// Update is called once per frame
	void Update () {
		currentColor = Color.Lerp(color1, color2, Mathf.PingPong(Time.time / alternateSpeed, 1));
		mat.SetColor("_EmissionColor", currentColor);
	}
}
