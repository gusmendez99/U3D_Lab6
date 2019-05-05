using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private bool mRunning;


    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        mRunning = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                mNavMeshAgent.destination = hit.point;
                              
            }
        }

        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            mRunning = false;
        }
        else
        {
            mRunning = true;
     
        }

        mAnimator.SetBool("running", mRunning);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Another collider...");
        if (other.gameObject.tag.Equals("PlaneFinish"))
        {
            GameObject.Find("EndText").GetComponent<Text>().text = "You won!!!";
            GameController.Instance.userHasWon = true;
            StartCoroutine(Stop());
            

        }

    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0.0f;
    }


}
