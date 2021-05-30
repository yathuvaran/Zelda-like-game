using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>(); //declare a ridgid body 
            if(enemy != null) //check if enemy has a ridgid body
            {
                enemy.GetComponent<Enemy>().currentState = EnemyState.stagger; //when enemy knocked put in stagger state
                Vector2 difference = enemy.transform.position - transform.position;
                //normalize to turn into vector that has length of 1
                difference =  difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle; //after some time reset enemy state to idle
        }
    }
}
