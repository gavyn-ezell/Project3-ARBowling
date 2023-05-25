using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bowlingSetupPrefab;
    GameObject currSetup;
    void Start()
    {
        currSetup = Instantiate(bowlingSetupPrefab);

    }
    public void resetLane()
    {
        Destroy(currSetup);
        currSetup = Instantiate(bowlingSetupPrefab);
    }

}
