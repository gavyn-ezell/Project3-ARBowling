using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingScript : MonoBehaviour
{

    public GameObject bowlingSetupPrefab;

    private bool isLaunched = false;
    private bool railsOn = false;
    private GameObject currSetup;
    private GameObject ballAnchor;
    private GameObject ball;
    private GameObject launchIndicator;
    public float launchPower;
    private float angleChange = 0.2f;
    
    void Start()
    {
        currSetup = Instantiate(bowlingSetupPrefab);
        currSetup.transform.Find("Rails").gameObject.SetActive(false);
        ballAnchor = currSetup.transform.Find("BallAnchor").gameObject;
        ball = ballAnchor.transform.Find("Ball").gameObject;
        launchIndicator = ballAnchor.transform.Find("Line").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        //already launched, restrict user input to just reset button
        if (isLaunched)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Destroy(currSetup);
                currSetup = Instantiate(bowlingSetupPrefab);
                currSetup.transform.Find("Rails").gameObject.SetActive(false);
                ballAnchor = currSetup.transform.Find("BallAnchor").gameObject;
                ball = ballAnchor.transform.Find("Ball").gameObject;
                launchIndicator = ballAnchor.transform.Find("Line").gameObject;
                isLaunched = false;
                railsOn = false;
            }
            return;
        }
        
        //user can setup their launch of the bowling ball
        if (Input.GetKeyDown("space"))
        {
            // Debug.Log("PUSH BALL");
            // Vector3 launchVector = Quaternion.AngleAxis(launchAngle, Vector3.up) * ballAnchor.forward; 
            ball.GetComponent<Rigidbody>().AddForce(ballAnchor.transform.forward * launchPower);
            isLaunched = true;
            launchIndicator.SetActive(false);

        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            bool nextState = !railsOn;
            railsOn = nextState;
            currSetup.transform.Find("Rails").gameObject.SetActive(nextState);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            ballAnchor.transform.rotation *= Quaternion.Euler(new Vector3(0,-angleChange,0)); 
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ballAnchor.transform.rotation *= Quaternion.Euler(new Vector3(0,angleChange,0)); 
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            ballAnchor.transform.rotation *= Quaternion.Euler(new Vector3(-angleChange,0,0)); 
        }
         else if (Input.GetKey(KeyCode.DownArrow))
        {
            ballAnchor.transform.rotation *= Quaternion.Euler(new Vector3(angleChange,0,0)); 
        }
        
    }

}
