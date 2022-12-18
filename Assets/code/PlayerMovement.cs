using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    bool gameover = false;

    Rigidbody2D rb;

    Camera cam;

    [SerializeField] Text score;

    

    

    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        cam = Camera.main;
    }

    

    void Update()
    {
        if (!gameover)
        {

            if (Input.GetKey (KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.forward * (-rotationSpeed) * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }
        }
    }

    void FixedUpdate()
    {
        if (!gameover)
        {
            rb.AddRelativeForce(new Vector3(moveSpeed*Time.fixedDeltaTime, 0f, 0f)); 
        }
    }

    void LateUpdate()
    {
        if (!gameover)
        {
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        }
    }

    void OnCollisionEnter2D()
    {
        if (!gameover)
        {
            gameover = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInChildren<ParticleSystem>().Play();
            Invoke("restart", 2f);
        }
    }

    void restart()
    {
        SceneManager.LoadScene(0);
    }
}
