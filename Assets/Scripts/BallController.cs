using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private LauncherControl LauncherReferance;
    [SerializeField] private Rigidbody2D rbBall;
    [SerializeField] private float randomForce = 0.2f;
    public bool isStarted = false;
    [SerializeField] private float yVelocity = 4f;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = LauncherReferance.transform; //making ball's transform the child of launcher's
        rbBall = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.parent = null; //after we clicked we don't want launcher ball couple
                rbBall.velocity = new Vector2(rbBall.velocity.x, yVelocity);
                isStarted = true;
            }
        }  
        
        /*if(Input.GetMouseButtonDown(1))
        {
            ballSpeedCoef(1.5f);
        }                                   //This part was for testing 
        if(Input.GetMouseButtonUp(1))
        {
            ballSpeedCoef(2f/3f);
        }*/
        //We can use statements below instead of parenting the ball to launcher, but if we
        //use these codes we need extra control statements
        //Vector2 LauncherPos = new Vector2(LauncherReferance.transform.position.x,
                                 // LauncherReferance.transform.position.y);
        
       // transform.position =  new Vector2(LauncherPos.x,LauncherPos.y + 0.2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip sound = ballSounds[Random.Range(0, ballSounds.Length)];
        if (collision.collider.gameObject.tag.Equals("Breakable"))
        {
            GetComponent<AudioSource>().PlayOneShot(sound);
            //if we say playoneshot it will play audio till it ends even if other one starts
            //this way we used external audio instead of choosing just one from the audiosource component
        }
        else
        {
            Vector2 velocityTweak = new Vector2(Random.Range(-randomForce, randomForce)
                                        , Random.Range(-randomForce, randomForce));
            rbBall.velocity += velocityTweak;
        }
    }

    public void ballSpeedCoef(float coefficient)
    {
        rbBall.velocity = rbBall.velocity * coefficient;
    }

}
