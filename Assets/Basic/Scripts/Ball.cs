using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(1,0)] public float speed = 2.0f;
    public GameObject prefab;

    private void Awake()
    {
        //This is the real constructor. Object may not be ready to start in the world
        print("Awake");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //This is similar to the constructor, but a little more requirements
        //Means object is ready to start in the world

        print("Start");

    }

    // Update is called once per frame
    void Update()
    {
        //The update for each frame
        Vector3 position = transform.position;
        Vector3 velocity = Vector3.zero;

       ////if(Input.GetKey(KeyCode.Space)) //this is like key down except keydown only registers changes in state not current state
       //if(Input.GetButton("Fire1")) //set these through input manager
       //{
       //    position.y += 1.0f * Time.deltaTime;
       //}

        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");

        //create prefab
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(prefab, transform.position + Vector3.up, Quaternion.identity);
        }

        transform.position += velocity * speed * Time.deltaTime;
    }
}
