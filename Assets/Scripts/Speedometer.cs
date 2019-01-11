using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour {

    public float maxVelocity = 200.0f;
    public Rigidbody objectToMeasure;

    private Image image;

    // Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        image.fillAmount = objectToMeasure.velocity.magnitude / maxVelocity;

	}
}
