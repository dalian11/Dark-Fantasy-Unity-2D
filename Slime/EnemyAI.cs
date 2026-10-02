using UnityEngine;
using UnityEngine.AI;
using KinghtAdventrue.Uniti;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimerMax = 2f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamngTime;
    private Vector3 roamPosition;
    private Vector3 startingPosition;



    private enum State
    {
        Idle,
        Roaming
    }



    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = startingState;
    }

    private void Update()
    {
        switch(state)
        {
            default:
            case State.Idle:
                break;
            case State.Roaming:
                roamngTime -= Time.deltaTime;
                if (roamngTime <0)
                {
                    Roaming();
                    roamngTime = roamingTimerMax;
                }

                break;
        }
    }

    private void Roaming()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
        ChangefacingDirection(startingPosition, roamPosition);
        navMeshAgent.SetDestination(roamPosition);
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + Uniti.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingTimerMax);
    }

    private void ChangefacingDirection(Vector3 sourPosition, Vector3 targetPosition)
    {
        if (sourPosition.x > targetPosition.x){
            transform.rotation = Quaternion.Euler(0, -180, 0);
         }else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
