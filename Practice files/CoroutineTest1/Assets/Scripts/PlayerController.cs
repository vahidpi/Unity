using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    public float counter;
    public Transform target;
    public float maxCount;

    NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    IEnumerator MyCoroutine()
    {
        while (Vector3.Distance(transform.position, target.position) > 0.05f)
        {

            if (counter < maxCount)
            {
                counter += Time.deltaTime;
               // Debug.Log(counter);
            }
            else
            {
                target.position = transform.position;
                counter = 0;
            }


            //Debug.Log(target.position);
            //counter =1f* Time.deltaTime;


            transform.position = Vector3.Lerp(transform.position, target.position, counter/maxCount);
            //agent.SetDestination(target.position);
            //agent.nextPosition= Vector3.Lerp(transform.position, target.position, counter / maxCount);
            //agent.SetDestination(Vector3.Lerp(transform.position, target.position, counter / maxCount));



            yield return null;
        }

        print("Reached the target.");

       // yield return new WaitForSeconds(3f);

       // print("MyCoroutine is now finished.");
    }

    // Update is called once per frame
    void Update () {
        //agent.SetDestination(target.position);
    }

    public void StartMoving(Transform targetpos)
    {
        //agent.SetDestination(targetpos.position);
        target = targetpos;
        StopCoroutine(MyCoroutine());
        StartCoroutine(MyCoroutine());
    }
}
