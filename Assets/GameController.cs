using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public float spawnPoint;
    public GameObject[] blockPrefab;
    float safeMargin = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        int k = Random.Range(0, blockPrefab.Length);
        if (spawnPoint < 10)
        {
            k = 0;
        }
        while (player != null && spawnPoint<player.transform.position.x + safeMargin)
        {
            GameObject temp = Instantiate(blockPrefab[k], transform.position, Quaternion.identity);
            PlatformController platform = temp.GetComponent<PlatformController>();
            temp.transform.position = new Vector3(spawnPoint + platform.platformSize / 2, 0, 0);
            spawnPoint = spawnPoint + platform.platformSize;
           
        }
        if (player != null)
        {
            cam.transform.position = new Vector3(player.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        }
    }
}
