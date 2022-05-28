using UnityEngine;

public class SkidSteering : MonoBehaviour
{
    float leftSpeed, rightSpeed;
    public float speed = 2.3f;
    public float treadDistance = 0.5f;

    [HideInInspector] 
    public TankController tankController;

    int direction = 0;
    float slowTread = 0; //tread closer to 0
    float fastTread = 0; //tread farther from 0

    float radius; //radius of inner drive circle
    float theta; //degrees to rotate
    float distance; //distance to move at angle

    Manager manager;

    private void Start()
    {
        manager = transform.parent.parent.GetComponentInChildren<Manager>();
    }

    void Update()
    {
        tankController = manager.activeSkippy.GetComponent<TankController>();
        leftSpeed = tankController.leftSpeed;
        rightSpeed = tankController.rightSpeed;
        Calculate(leftSpeed, rightSpeed);
    }

    void Calculate(float leftSpeed, float rightSpeed)
    {
   
        if (leftSpeed == rightSpeed) //going straight
        {
            manager.activeSkippy.transform.Translate(new Vector3(0, 0, speed * leftSpeed * Time.deltaTime));
        }
        else
        {
            //set fast & slow treads
            if (Mathf.Abs(leftSpeed) < Mathf.Abs(rightSpeed))
            {
                direction = -1;
                slowTread = leftSpeed;
                fastTread = rightSpeed;
            }
            else
            {
                direction = 1;
                fastTread = leftSpeed;
                slowTread = rightSpeed;
            }

            fastTread *= Time.deltaTime; 
            slowTread *= Time.deltaTime;

            //calculacte radius of inner drive circle
            if (slowTread == 0) radius = 0;
            else radius = treadDistance / ((fastTread / slowTread) - 1);

            //calculate theta (degrees to rotate): add treadDistance (and use fastTread) to avoind divistion by 0
            theta = (fastTread / (radius + treadDistance)); 
            
            //calculate travel distance
            distance = ((radius + treadDistance / 2) * Mathf.Sin(theta / 2) * 2);

            //do the moving
            Move();

        }
    }

    void Move()
    {
        manager.activeSkippy.transform.Rotate(new Vector3(0, (Mathf.Rad2Deg * theta / 2) * direction, 0)); //rotate halfway
        manager.activeSkippy.transform.Translate(new Vector3(0, 0, speed * distance)); //move
        manager.activeSkippy.transform.Rotate(new Vector3(0, (Mathf.Rad2Deg * theta / 2) * direction, 0)); //rotate the rest
    }

}
