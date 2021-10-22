using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentStatus : MonoBehaviour
{
    [SerializeField] private Text agentName;
    [SerializeField] private Text lifePoint;
    public GameObject agentViewObject;

    public string nameAgent;
    public string lifePoints;
    public AgentStatus (string name, string life)
    {
        ChangeStaus(name, life);
    }

    public void ChangeStaus(string name, string life)
    {
        nameAgent = name;
        lifePoints = life;
        agentName.text = name;
        lifePoint.text = life;
    }
}
