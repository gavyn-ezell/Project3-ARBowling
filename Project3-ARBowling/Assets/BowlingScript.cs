using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingScript : MonoBehaviour
{
    private SetupSpawner spawner;
    //canvas elements
    public Slider horizontalSlider;
    public Slider vertSlider;
    public Slider powerSlider;
    public Toggle guardToggle;
    
    //bowling lane elements
    public GameObject currSetup;
    public GameObject ballAnchor;
    public GameObject ball;
    public GameObject launchIndicator;
    private bool isLaunched = false;
    public float launchPower;
    
    
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<SetupSpawner>();
        currSetup.transform.Find("Rails").gameObject.SetActive(false);
        // ballAnchor = currSetup.transform.Find("BallAnchor").gameObject;
        // ball = ballAnchor.transform.Find("Ball").gameObject;
        // launchIndicator = ballAnchor.transform.Find("Line").gameObject;
    }
    // Update is called once per frame

    void Update()
    {
        //Debug.Log((float)horizontalSlider.value);
        // Debug.Log(spawner);
        if (!isLaunched)
        {
            ball.transform.rotation = ballAnchor.transform.rotation * Quaternion.Euler(Vector3.up * horizontalSlider.value) * Quaternion.Euler(Vector3.right * -vertSlider.value);
            launchPower = powerSlider.value;
        }
    }
    // public void horizontalAngleChange()
    // {
    //     Debug.Log("HELLO");
    //     float angleVal = horizontalSlider.value;
    //     Debug.Log(angleVal);
    //     Debug.Log(ballAnchor);
    //     ballr.transform.rotation = ballAnchor.transform.rotation * Quaternion.Euler(Vector3.up * angleVal);
    // }
    // public void verticalAngleChange()
    // {
    //     float angleVal = vertSlider.value;
    //     ballAnchor.transform.rotation = ballAnchor.transform.rotation * Quaternion.Euler(Vector3.right * angleVal);
    // }
    public void launchBall()
    {
        if (isLaunched)
        {
            return;
        }
        ball.transform.Find("Line").gameObject.SetActive(false);
        ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * launchPower);
        isLaunched = true;
        launchIndicator.SetActive(false);
    }

    public void manageRails()
    {
        if (guardToggle.isOn)
        {
            currSetup.transform.Find("Rails").gameObject.SetActive(true);
        }
        else
        {
            currSetup.transform.Find("Rails").gameObject.SetActive(false);
        }

    }

    public void resetLane()
    {
        spawner.resetLane();
    }


}
