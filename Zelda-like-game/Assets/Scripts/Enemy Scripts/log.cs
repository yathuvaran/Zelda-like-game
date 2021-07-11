using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : Enemy
{
    public Rigidbody2D myRigidbody;
    public Transform target; //Transform bc we want a location in space not an entire game object
    public float chaseRadius; //inside the radius where log chases player
    public float attackRadius; //inside the radius log attacks player
    public Transform homePosition; //if player moves outside of chase radius go back to homePosition
    public Animator anim; //reference to animator

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //transform holds scale, rotation and position
        //thats all we need to know to find out where the object needs to move towards
        target = GameObject.FindWithTag("Player").transform;
        anim.SetBool("wakeUp", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius 
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
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }

    public void changeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
