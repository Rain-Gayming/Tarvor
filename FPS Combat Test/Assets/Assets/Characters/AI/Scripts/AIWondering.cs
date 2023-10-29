using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

public class AIWondering : MonoBehaviour
{
    [BoxGroup("References")]
    public NavMeshAgent agent;

    
    [BoxGroup("Wait Time")]
    public float minWaitTime;
    [BoxGroup("Wait Time")]
    public float maxWaitTime;
    [BoxGroup("Wait Time")]
    public float waitTimer;
    [BoxGroup("Wait Time")]
    public bool waiting;

    [BoxGroup("Current Target")]
    public AISpot currentTarget;
    [BoxGroup("Current Target")]
    public float currentX;
    [BoxGroup("Current Target")]
    public float currentZ;
    [BoxGroup("Current Target")]
    public List<AISpot> recentlyVisitedSpots;

    public void Update()
    {

        if(!currentTarget){
            waiting = false;
            print("Searching for target");
            int randomTarget = Random.Range(0, AIWorldManager.instance.movePoints.Count);
            
            if(recentlyVisitedSpots.Contains(AIWorldManager.instance.movePoints[randomTarget]) == false){
                currentTarget = AIWorldManager.instance.movePoints[randomTarget];
                print("Found spot " + currentTarget);
                agent.SetDestination(currentTarget.transform.position);

                if(recentlyVisitedSpots.Count >= 6){
                    recentlyVisitedSpots.RemoveAt(5);
                    recentlyVisitedSpots.Add(currentTarget);
                }else{
                    recentlyVisitedSpots.Add(currentTarget);
                }

                currentX = currentTarget.transform.position.x;
                currentZ = currentTarget.transform.position.z;
            }
            
        }

        if(transform.position.z == currentZ){
            if(transform.position.x == currentX){
                if(!waiting && currentTarget){
                    waiting = true;
                    waitTimer = Random.Range(minWaitTime, maxWaitTime);
                }

                if(waiting){
                    waitTimer -= Time.deltaTime;
                    waitTimer = Mathf.Clamp(waitTimer, -1, maxWaitTime);

                    if(waitTimer <= 0){
                        currentTarget = null;
                        waiting = false;
                    }
                }
            }
        }
    }
}
