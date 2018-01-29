using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoplightController : MonoBehaviour {

    public Material redMat;
    public Material greenMat;
    public Material yellowMat;
    public Material offMat;

    public GameObject greenLight;
    public GameObject yellowLight;
    public GameObject redLight;

	// Use this for initialization
	void Awake () {
        greenLight.GetComponent<Renderer>().material = offMat;
        yellowLight.GetComponent<Renderer>().material = offMat;
        redLight.GetComponent<Renderer>().material = redMat;
    }
	
    public void ChangeLight(PhaseState state)
    {
        if(state == PhaseState.ACTIVE)
        {
            greenLight.GetComponent<Renderer>().material = greenMat;
            yellowLight.GetComponent<Renderer>().material = offMat;
            redLight.GetComponent<Renderer>().material = offMat;
        }
        else if(state == PhaseState.NOT_ACTIVE)
        {
            greenLight.GetComponent<Renderer>().material = offMat;
            yellowLight.GetComponent<Renderer>().material = offMat;
            redLight.GetComponent<Renderer>().material = redMat;
        }
        else if(state == PhaseState.TRANSITION)
        {
            greenLight.GetComponent<Renderer>().material = offMat;
            yellowLight.GetComponent<Renderer>().material = yellowMat;
            redLight.GetComponent<Renderer>().material = offMat;
        }
    }
}
