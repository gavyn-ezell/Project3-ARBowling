using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bowlingSetupPrefab;
    public Camera mainCam;
    private GameObject currSetup;
    void Start()
    {
        currSetup = Instantiate(bowlingSetupPrefab);
        currSetup.transform.Find("BowlingGameCanvas").gameObject.GetComponent<Canvas>().worldCamera = mainCam;
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("YO");
            // resetLane();
        }
    }
    public void resetLane()
    {
        Destroy(currSetup);
        currSetup = Instantiate(bowlingSetupPrefab);
        currSetup.transform.Find("BowlingGameCanvas").gameObject.GetComponent<Canvas>().worldCamera = mainCam;
    }
}
