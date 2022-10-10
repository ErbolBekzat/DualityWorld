using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float rollSpeed;
    [SerializeField] private float delay;

    private bool moving;

    private Vector3 direction = new Vector3();

    private List<Transform> currentObstacles = new List<Transform>();

    private void RollCube(Vector3 direction)
    {
        Vector3 anchor = transform.position + (Vector3.down + direction) * .5f;
        Vector3 axis = Vector3.Cross(Vector3.up, direction);
        StartCoroutine(Roll(anchor, axis));
    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        moving = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(delay);
        }

        moving = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            currentObstacles.Remove(collision.transform);
        }

        if (collision.transform.tag == "SnowBall")
        {
            currentObstacles.Remove(collision.transform);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;


            if (direction.x >= .9f && CheckObstaclePosition(Vector3.left))
            {
                if (!moving)
                {
                    this.direction = Vector3.left;
                    RollCube(this.direction);
                }
            }
            if (direction.x <= -.9f && CheckObstaclePosition(Vector3.right))
            {
                if (!moving)
                {
                    this.direction = Vector3.right;
                    RollCube(this.direction);
                }
            }
            if (direction.z >= .9f && CheckObstaclePosition(Vector3.back))
            {
                if (!moving)
                {
                    this.direction = Vector3.back;
                    RollCube(this.direction);
                }
            }
            if (direction.z <= -.9f && CheckObstaclePosition(Vector3.forward))
            {
                if (!moving)
                {
                    this.direction = Vector3.forward;
                    RollCube(this.direction);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            currentObstacles.Add(collision.transform);
        }

        if (collision.transform.tag == "SnowBall")
        {
            currentObstacles.Add(collision.transform);
        }
        
        if (collision.transform.tag == "Player")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;


            if (direction.x >= .9f && CheckObstaclePosition(Vector3.left))
            {
                if (!moving)
                {
                    this.direction = Vector3.left;
                    RollCube(this.direction);
                }
            }
            if (direction.x <= -.9f && CheckObstaclePosition(Vector3.right))
            {
                if (!moving)
                {
                    this.direction = Vector3.right;
                    RollCube(this.direction);
                }
            }
            if (direction.z >= .9f && CheckObstaclePosition(Vector3.back))
            {
                if (!moving)
                {
                    this.direction = Vector3.back;
                    RollCube(this.direction);
                }
            }
            if (direction.z <= -.9f && CheckObstaclePosition(Vector3.forward))
            {
                if (!moving)
                {
                    this.direction = Vector3.forward;
                    RollCube(this.direction);
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
}
