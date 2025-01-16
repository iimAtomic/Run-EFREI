using UnityEngine;
using DG.Tweening;

public class RunnerController : MonoBehaviour
{
    public float laneSize;
    public float speed;
    public float jumpForce;
    //True = gauche, false = droite
    public bool lane = false;

    public Rigidbody rigidBody;
    public GameObject playerVisual;
    public LayerMask groundLayer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ///Movement forward
        this.transform.position += this.transform.forward * (speed * Time.deltaTime);

        ///Lane switching
        if (lane == true)
        {
            playerVisual.transform.position = this.transform.position + this.transform.right * laneSize;
        }
        else
        {
            playerVisual.transform.position = this.transform.position - this.transform.right * laneSize;
        }

        if (Input.GetKeyDown(KeyCode.A) && lane == false)
        {
            changeLane();
        }
        else if (Input.GetKeyDown(KeyCode.D) && lane == true)
        {
            changeLane();
        }
        // Appliquer le saut si au sol et touche "Espace" pressée
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }
    bool CheckIfGrounded()
    {
        // Vérifie si le personnage touche le sol
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }

    void changeLane()
    {
        lane = !lane;
    }
    void jump()
    {
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

}
