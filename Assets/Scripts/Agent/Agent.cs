using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private GameObject selectedPlane;
    [SerializeField] private Rigidbody agentRigidBody;
    private int lifePoints = 3;
    private float timer = 0;
    private float timeToChangeDirection = 0.5f;
    private Vector3 directionMove;

    private bool wasHit;
    private float timerHit;

    private void Update()
    {
        timer = timer + Time.deltaTime;
        if(timer > timeToChangeDirection)
        {
            Direction();
            SetNewTime();
        }
        CheckIfWasHit();
    }

    private void HitAgent()
    {
        directionMove = -directionMove;
        ChangeMoveDirection();
        RemoveLife();
    }   
    
    private void CheckIfWasHit()
    {
        if(wasHit)
        {
            timerHit = timerHit + Time.deltaTime;
            if(timerHit > 0.2f)
            {
                wasHit = false;
                timerHit = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Agent" && !wasHit)
        {
            HitAgent();
        }else
        {
            Direction();
        }
    }

    public void Selected(bool select)
    {
        selectedPlane.SetActive(select);
    }

    private void RemoveLife()
    {
        if(lifePoints == 1)
        {
            DestroyAgent();
        }else
        {
            wasHit = true;
            lifePoints--;
        }
    }

   
    private void DestroyAgent()
    {
       // MediatorController.Instance.RemoveAgent(this.GetComponent<Agent>());
        Destroy(this.gameObject);
    }

    private void SetNewTime()
    {
        timer = 0;
        timeToChangeDirection = GetRandomNumber(1, 4);
    }
    private void Direction()
    {
        SetVectorToMove();
        ChangeMoveDirection();
    }

    private void ChangeMoveDirection()
    {
        agentRigidBody.velocity = Vector3.zero;
        agentRigidBody.velocity = directionMove * 10f;
    }

    private void SetVectorToMove()
    {
        directionMove = new Vector3(CheckIfNumberIsZeroToDirection(-10,10), 0, CheckIfNumberIsZeroToDirection(-10,10));
    }

    private float CheckIfNumberIsZeroToDirection(float min, float max)
    {
        float number = GetRandomNumber(min, max);
        if (number != 0)
        {
            return number / 10;
        }
        else
        {
            return 0;
        }
    }

    private float GetRandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }
}
