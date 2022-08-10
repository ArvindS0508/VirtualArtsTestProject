using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private static float PLAYER_SPEED_VAL = 4.0f;
    private float playerSpeed = PLAYER_SPEED_VAL;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector3 playerScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScaleReverse = new Vector3(1, 1, 1);
    public Transform cameraTransform;
    private bool checkCeiling;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //groundedPlayer = controller.isGrounded;
        groundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        //transform.position = transform.position + Camera.main.transform.forward * Time.deltaTime;

        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        move = cameraTransform.TransformDirection(move);
        controller.Move(move * Time.deltaTime * playerSpeed);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        checkCeiling = Physics.Raycast(this.transform.position, Vector3.up, 2.0f, -1);

        if (Input.GetButton("Fire1"))
        {
            gameObject.transform.localScale = playerScale;
            //gameObject.transform.Translate(0, -100, 0);
            controller.Move(new Vector3(0, -0.5f, 0));
            playerSpeed = 0.5f * PLAYER_SPEED_VAL;
        }
        else if (!checkCeiling)
        {
            gameObject.transform.localScale = playerScaleReverse;
            playerSpeed = PLAYER_SPEED_VAL;
        }
        else
        {
            gameObject.transform.localScale = playerScale;
            //gameObject.transform.Translate(0, -100, 0);
            controller.Move(new Vector3(0, -0.5f, 0));
            playerSpeed = PLAYER_SPEED_VAL;
        }
        if (Input.GetButton("Fire3"))
        {
            playerSpeed = 2f * PLAYER_SPEED_VAL;
        }
        else
        {

            playerSpeed = PLAYER_SPEED_VAL;
        }



        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("interact");
        }
        if (Input.GetButtonDown("Exit"))
        {
            Debug.Log("bye");
            Application.Quit();
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

}
