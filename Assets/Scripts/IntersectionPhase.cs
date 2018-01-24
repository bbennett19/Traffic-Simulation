using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public enum PhaseState { ACTIVE, TRANSITION, NOT_ACTIVE }

public class IntersectionPhase
{
    private float m_activeTime;
    private int m_phaseNum;
    private int m_nextPhase;
    private float m_transitionTime;
    private PhaseState m_currentState = PhaseState.NOT_ACTIVE;
    private StoplightController[] m_stoplights;

    public IntersectionPhase(float activeTime, float transitionTime, int phaseNum, int nextPhase, StoplightController[] stopLights)
    {
        
        m_activeTime = activeTime;
        m_transitionTime = transitionTime;
        m_phaseNum = phaseNum;
        m_nextPhase = nextPhase;
        m_stoplights = stopLights;
    }

    public float ActiveTime { get { return m_activeTime; } }
    public float TransitionTime { get { return m_transitionTime; } }
    public int PhaseNum { get { return m_phaseNum; } }
    public int NextPhase { get { return m_nextPhase; } }
    public PhaseState CurrentState { get { return m_currentState; } }

    public void SetPhaseState(PhaseState state)
    {
        m_currentState = state;
        foreach(StoplightController s in m_stoplights)
        {
            s.ChangeLight(m_currentState);
        }
    }
}

