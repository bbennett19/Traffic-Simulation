﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionController : MonoBehaviour {
    private IntersectionPhase[] m_phases;
    private float m_elapsedTime = 0.0f;
    private int m_currentPhase = 0;
    public StoplightController[] lightToPhase_0;
    public StoplightController[] lightToPhase_1;
    public StoplightController[] lightToPhase_2;
    public StoplightController[] lightToPhase_3;

    // Use this for initialization
    void Start () {
        m_phases = new IntersectionPhase[2];
        m_phases[0] = new IntersectionPhase(10f, 3f, 0, 1, lightToPhase_0);
        m_phases[1] = new IntersectionPhase(10f, 3f, 1, 0, lightToPhase_1);
        m_phases[m_currentPhase].SetPhaseState(PhaseState.ACTIVE);
    }
	
	// Update is called once per frame
	void Update () {
        m_elapsedTime += Time.deltaTime;

        if(m_phases[m_currentPhase].CurrentState == PhaseState.TRANSITION && m_elapsedTime >= m_phases[m_currentPhase].TransitionTime)
        {
            Debug.Log(m_currentPhase.ToString() + " NEXT");
            m_phases[m_currentPhase].SetPhaseState(PhaseState.NOT_ACTIVE);
            m_currentPhase = m_phases[m_currentPhase].NextPhase;
            m_phases[m_currentPhase].SetPhaseState(PhaseState.ACTIVE);
            m_elapsedTime = 0.0f;
        }
        else if(m_phases[m_currentPhase].CurrentState == PhaseState.ACTIVE && m_elapsedTime >= m_phases[m_currentPhase].ActiveTime)
        {
            Debug.Log(m_currentPhase.ToString() + " TRANSITION");
            m_phases[m_currentPhase].SetPhaseState(PhaseState.TRANSITION);
            m_elapsedTime = 0.0f;
        }
		
	}
}