using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour {

    public int mapSize = 5;
    public GameObject platformObj;
    public float offset = 0.05f;
    private Vector3 platformDim;

	// Use this for initialization
	void Start () {

        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++) {
                GameObject platform = Instantiate(platformObj, transform.position, Quaternion.identity) as GameObject;
                platform.transform.parent = gameObject.transform;
                platformDim = platform.GetComponent<BoxCollider>().bounds.size;
                platform.transform.position = new Vector3(transform.position.x + (x * (platformDim.x + offset)), transform.position.y, transform.position.z + (z * (platformDim.z + offset)));
                platform.name = (x + z).ToString();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
 