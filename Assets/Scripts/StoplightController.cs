using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoplightController : MonoBehaviour {
    public float greenTime;
    public float yellowTime;
    public float redTime;

    public Material redMat;
    public Material greenMat;
    public Material yellowMat;
    public Material offMat;

    public GameObject greenLight;
    public GameObject yellowLight;
    public GameObject redLight;

    private float _elapsed = 0f;
    private int _currentState = 0;

	// Use this for initialization
	void Start () {
        greenLight.GetComponent<Renderer>().material = greenMat;
        yellowLight.GetComponent<Renderer>().material = offMat;
        redLight.GetComponent<Renderer>().material = offMat;
    }
	
	// Update is called once per frame
	void Update () {
        _elapsed += Time.deltaTime;

        if(_currentState == 0 && _elapsed >= greenTime)
        {
            // transition to yellow
            greenLight.GetComponent<Renderer>().material = offMat;
            yellowLight.GetComponent<Renderer>().material = yellowMat;
            _currentState = 1;
            _elapsed = 0f;
        }
        else if(_currentState == 1 && _elapsed >= yellowTime)
        {
            // transition to red
            yellowLight.GetComponent<Renderer>().material = offMat;
            redLight.GetComponent<Renderer>().material = redMat;
            _currentState = 2;
            _elapsed = 0f;
        }
        else if(_currentState == 2 && _elapsed >= redTime)
        {
            // transition to green
            greenLight.GetComponent<Renderer>().material = greenMat;
            redLight.GetComponent<Renderer>().material = offMat;
            _currentState = 0;
            _elapsed = 0f;
        }
	}
}
