using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] private float normalSpeed;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {   
           
            Move(transform.forward.normalized);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            Move(transform.forward.normalized);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(transform.forward.normalized);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(transform.forward.normalized);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Walk", false);
        }


    }

    private void Move(Vector3 direction)
    {
        animator.SetBool("Walk", true);
        transform.position += direction * normalSpeed * Time.deltaTime;
    }    
}
