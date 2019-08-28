using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator = null;
    [SerializeField] private float speed = 5;

    private float distanceTravelled;

    [SerializeField] private bool canMove = true;
    [SerializeField] private bool backingToPath = false;

    private Quaternion rot; // rotation to look to the way of the path

    private void FixedUpdate()
    {
        if (backingToPath)
            BackToPath();
        else if (canMove)
            MoveInThePath();

    }

    private void MoveInThePath()
    {
        distanceTravelled += Speed * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pathCreator.path.GetPointAtDistance(distanceTravelled), Speed * Time.fixedDeltaTime);

        //Set rotation of the object
        //------------------
        Vector3 direction;
        float angle;

        direction = pathCreator.path.GetPointAtDistance(distanceTravelled + Speed * Time.fixedDeltaTime) - transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //-----------------
    }

    private void BackToPath()
    {
        //Set rotation of the object
        //------------------
        Vector3 direction;
        float angle;

        direction = pathCreator.path.GetPointAtDistance(distanceTravelled) - transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //-----------------


        transform.position = Vector3.MoveTowards(transform.position, pathCreator.path.GetPointAtDistance(distanceTravelled), Speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, pathCreator.path.GetPointAtDistance(distanceTravelled)) <= 0.1f)
            backingToPath = false;
    }

    public float Speed { get => speed; set => speed = value; }
}
