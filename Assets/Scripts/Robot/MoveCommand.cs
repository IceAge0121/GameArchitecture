using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
    private NavMeshAgent agent;
    private Vector3 destination;

    //Constructor
    public MoveCommand(NavMeshAgent _agent, Vector3 _destination)
    {
        agent = _agent;
        destination = _destination;
    }

    public override bool isComplete => ReachedDestination();

    public override void Execute()
    {
        agent.SetDestination(destination);
    }

    bool ReachedDestination()
    {
        if (agent.remainingDistance > 0.1f)
        {
            return false;
        }

        return true;
    }
}
