using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuilderCommand : Command
{
    private NavMeshAgent agent;
    private Builder builder;

    public BuilderCommand(NavMeshAgent _agent, Builder _builder)
    {
        agent = _agent;
        builder = _builder;
    }

    public override bool isComplete => BuildComplete();

    public override void Execute()
    {
        agent.SetDestination(builder.transform.position);
    }

    bool BuildComplete()
    {
        if(agent.remainingDistance > 0.1f)
        {
            return false;
        }

        if(builder != null)
        {
            builder.Build();
        }
        return true;
    }
}
