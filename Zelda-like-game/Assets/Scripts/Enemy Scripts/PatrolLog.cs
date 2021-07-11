using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : log
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            //so that we don't move towards player in attack or stagger states
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                //moveSpeed * Time.deltaTime so that it averages out to moveSpeed per Second
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position); //to get the actual amount of the movement thats happening
                myRigidbody.MovePosition(temp);
                //ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, currentGoal.position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, currentGoal.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position); //to get the actual amount of the movement thats happening
                myRigidbody.MovePosition(temp);

            }
            else
            {
                ChangeGoal();
            }

        }
    }

    private void ChangeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
        }
        else
        {
            currentPoint++;
        }
        currentGoal = path[currentPoint];
    }


}
