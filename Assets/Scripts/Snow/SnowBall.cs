using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rigidbody;

    private Vector3 direction;

    private bool moving = false;

    private List<Transform> currentObstacles = new List<Transform>();

    private Vector3 lastDirection = new Vector3();
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (moving)
        {
            transform.position += new Vector3(direction.x, 0, direction.z) * speed * Time.deltaTime;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            currentObstacles.Remove(collision.transform);
        }
        if (collision.transform.tag == "Cube")
        {
            currentObstacles.Remove(collision.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lava" || collision.gameObject.tag == "Finish")
        {
            collision.gameObject.GetComponent<Lava>().TurnIntoIce();
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Obstacle")
        {
            currentObstacles.Add(collision.transform);

            if (!CheckObstaclePosition(lastDirection))
            {
                moving = false;
                rigidbody.isKinematic = false;
                rigidbody.useGravity = true;
            }
            
        }
        if (collision.transform.tag == "Cube")
        {
            currentObstacles.Add(collision.transform);

            if (!CheckObstaclePosition(lastDirection))
            {
                moving = false;
                rigidbody.isKinematic = false;
                rigidbody.useGravity = true;
            }
        }

        if (collision.contactCount < 2 && collision.transform.tag == "Player")
        {
            Vector3 collidedDirection = (collision.transform.position - transform.position).normalized;

            if (collidedDirection.x >= .8f && CheckObstaclePosition(Vector3.left))
            {
                if (!moving)
                {
                    direction = Vector3.left;
                    moving = true;

                    lastDirection = Vector3.left;
                }
            }
            if (collidedDirection.x <= -.8f && CheckObstaclePosition(Vector3.right))
            {
                if (!moving)
                {
                    direction = Vector3.right;
                    moving = true;

                    lastDirection = Vector3.right;
                }
            }
            if (collidedDirection.z >= .8f && CheckObstaclePosition(Vector3.back))
            {
                if (!moving)
                {
                    direction = Vector3.back;
                    moving = true;

                    lastDirection = Vector3.back;
                }
            }
            if (collidedDirection.z <= -.8f && CheckObstaclePosition(Vector3.forward))
            {
                if (!moving)
                {
                    direction = Vector3.forward;
                    moving = true;

                    lastDirection = Vector3.forward;
                }
            }
        }
    }

    private bool CheckObstaclePosition(Vector3 direction)
    {
        bool result = true;

        int index = 0;

        if (currentObstacles.Count > 0)
        {
            if (direction == Vector3.forward)
            {
                foreach (Transform currentObstacle in currentObstacles)
                {
                    if (index > 0 && result == false)
                    {
                        result = false;
                    }
                    else
                    {
                        index++;
                        if (currentObstacle.position.z <= transform.position.z)
                        {
                            result = true;
                        }
                        else if (currentObstacle.position.z >= transform.position.z &&
                            (currentObstacle.position.x >= transform.position.x + .5f || currentObstacle.position.x <= transform.position.x - .5f))
                        {
                            result = true;
                        }
                        else if (currentObstacle.position.z >= transform.position.z &&
                            (currentObstacle.position.x <= transform.position.x + .2f && currentObstacle.position.x >= transform.position.x - .2f))
                        {
                            result = false;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                
            }

            if (direction == Vector3.right)
            {
                foreach (Transform currentObstacle in currentObstacles)
                {
                    if (index > 0 && result == false)
                    {
                        result = false;
                    }
                    else
                    {
                        index++;
                        if (currentObstacle.position.x <= transform.position.x)
                        {
                            result = true;
                        }
                        else if (currentObstacle.position.x >= transform.position.x &&
                            (currentObstacle.position.z >= transform.position.z + .5f || currentObstacle.position.z <= transform.position.z - .5f))
                        {
                            result = true;
                        }
                        else if (currentObstacle.position.x >= transform.position.x &&
                            (currentObstacle.position.z <= transform.position.z + .2f && currentObstacle.position.z >= transform.position.z - .2f))
                        {
                            result = false;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }

            if (direction == Vector3.back)
            {
                foreach (Transform currentObstacle in currentObstacles)
                {
                    if (index > 0 && result == false)
                    {
                        result = false;
                    }
                    else
                    {
                        index++;
                        if (currentObstacle.position.z >= transform.position.z)
                        {
                            result = true;
                        }
                        else if (currentObstacle.position.z <= transform.position.z &&
                            (currentObstacle.position.x >= transform.position.x + .5f || currentObstacle.position.x <= transform.position.x - .5f))
                        {
                            result = true;
                        }
                        else if (currentObstacle.position.z <= transform.position.z &&
                            (currentObstacle.position.x <= transform.position.x + .2f && currentObstacle.position.x >= transform.position.x - .2f))
                        {
                            result = false;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }

            if (direction == Vector3.left)
            {
                foreach (Transform currentObstacle in currentObstacles)
                {
                    if (index > 0 && result == false)
                    {
                        result = false;
                    }
                    else
                    {
                        index++;
                        if (currentObstacle.position.x >= transform.position.x)
                        {
                            result = true;
                        }
                        else if (currentObstacle.position.x <= transform.position.x &&
                            (currentObstacle.position.z >= transform.position.z + .5f || currentObstacle.position.z <= transform.position.z - .5f))
                        {
                            result = true;
                        }
                        else if (currentObstacle.position.x <= transform.position.x &&
                            (currentObstacle.position.z <= transform.position.z + .2f && currentObstacle.position.z >= transform.position.z - .2f))
                        {
                            result = false;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
        }
        
        return result;
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
        lastDirection = newDirection;
    }
}
