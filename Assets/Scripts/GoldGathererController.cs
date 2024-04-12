using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoldGathererController : MonoBehaviour
{
    private int healthPoints = 3;
    private int currentHealthPoints;

    private float dieTime = 5.0f;
    private float remainingDieTime;

    private float waitTime = 5.0f;
    private float remainingWaitTime;

    private float gatherTime = 2.0f;
    private float remainingGatherTime;

    private bool isAttacked=false;

    public NavMeshAgent m_NavMeshAgent;

    public bool isPlayer;

    public PlayerBase m_PlayerBase;

    public enum GoldGathererStates
    {
        NONE = -1,
        GO_TO_GOLD_POINT,
        CHECK_ARRIVAL,
        GATHER,
        RUN_TO_SAFE_PLACE,
        WAITING
    }

    public GoldGathererStates currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentHealthPoints = healthPoints;

        remainingDieTime = dieTime;
        remainingWaitTime = waitTime;
        remainingGatherTime = gatherTime;

        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_PlayerBase = FindObjectOfType<PlayerBase>();

        currentState= GoldGathererStates.GO_TO_GOLD_POINT;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        if (isAttacked)
        {
            TakeDamage(healthPoints, dt);
        }
        switch (currentState)
        {
            case GoldGathererStates.GO_TO_GOLD_POINT:
                GoToGoldPoint(m_PlayerBase);
                break;
            case GoldGathererStates.CHECK_ARRIVAL:
                CheckArrival(m_PlayerBase);
                break;
            case GoldGathererStates.GATHER:
                Gather(dt, m_PlayerBase, m_PlayerBase.numGold);
                break;
            case GoldGathererStates.RUN_TO_SAFE_PLACE:
                RunToSafePlace(m_PlayerBase);
                break;
            case GoldGathererStates.WAITING:
                Wait(dt);
                break;
        }
    }


    public void GoToGoldPoint(PlayerBase playerBase)
    {
        m_NavMeshAgent.SetDestination(playerBase.m_GoldPoint.position);
        m_NavMeshAgent.isStopped = false;
        currentState = GoldGathererStates.CHECK_ARRIVAL;
    }

    public void CheckArrival(PlayerBase playerBase)
    {
        //if (m_NavMeshAgent.path != null)
        //{
            if (m_NavMeshAgent.remainingDistance <= m_NavMeshAgent.stoppingDistance)
            {
                m_NavMeshAgent.isStopped = true;
                currentState = GoldGathererStates.GATHER;
            }
            /*if (m_NavMeshAgent.pathEndPosition == m_NavMeshAgent.path.corners[m_NavMeshAgent.path.corners.Length - 1])
            {
                if (m_NavMeshAgent.remainingDistance < 1.0f)
                {
                    m_NavMeshAgent.isStopped = true;
                    currentState = GoldGathererStates.GATHER;
                }

                

                if (this.m_NavMeshAgent.destination == playerBase.m_GoldPoint.position)
                {
                    currentState = GoldGathererStates.GATHER;
                }
                else if (m_NavMeshAgent.destination == playerBase.m_RunningPoint.position)
                {
                    currentState = GoldGathererStates.WAITING;
                }
               }
            }*/
       // }
    }

    public void Gather(float dt, PlayerBase playerBase, int gold)
    {
        while (isAttacked==false)
        {
            if (remainingGatherTime > 0)
            {
                remainingGatherTime -= dt;
            }
            else
            {
                playerBase.AddGold(gold);
                remainingGatherTime = gatherTime;
            }
        }
    }

    public void RunToSafePlace(PlayerBase playerBase)
    {
        m_NavMeshAgent.SetDestination(playerBase.m_RunningPoint.position);
        m_NavMeshAgent.isStopped = false;
        currentState = GoldGathererStates.CHECK_ARRIVAL;
    }

    public void Wait(float dt)
    {
        if(remainingWaitTime > 0)
        {
            remainingWaitTime -= dt;
        }
        else
        {
            currentState = GoldGathererStates.GO_TO_GOLD_POINT;
        }
    }

    public void TakeDamage(int health, float dt)
    {
        if(health > 0)
        {
            health -= 1;
        }
        else
        {
            if (remainingDieTime > 0)
            {
                remainingDieTime -= dt;
            }
            else
            {
                remainingDieTime = dieTime;
                Destroy(gameObject);
            }
        }
    }

    /*
    public void Die(int health, float dt)
    {
        if (health <= 0)
        {
            if (remainingDieTime > 0)
            {
                remainingDieTime -= dt;
            }
            else
            {
                remainingDieTime = dieTime;
                Destroy(gameObject);
            }
        }
    }*/
}
