using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {

	[SerializeField]
	private Text valText;

	private Slider slider;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		UpdateValueText();
		slider.onValueChanged.AddListener(delegate {UpdateValueText();});
	}

	void UpdateValueText(){
		valText.text = slider.value.ToString();
	}
}
