using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class CityGenerator : MonoBehaviour
{
    bool played_player = false;
    public GameObject player_prefab;
    public GameObject camera_prefab;

    float ground_size = 40;
    public GameObject ground_prefab;

    float floor_offset = 4f;
    float floor_height = 8f;
    public GameObject floor_prefab;

    void Start()
    {
        for (int i = -25; i < 25; i++)
        {
            for (int j = -25; j < 25; j++)
            {
                Vector3 location = new Vector3(i * ground_size, 0, j * ground_size);
                GameObject ground = Instantiate(ground_prefab, location, Quaternion.identity);

                if (Random.Range(0, 100) < 10)
                {
                    int building_height = Random.Range(1, 10);
                    for (int k = 0; k < building_height; k++)
                    {
                        Instantiate(floor_prefab, location + new Vector3(0, k * floor_height + floor_offset, 0), Quaternion.identity);
                    }
                }
                else if (!played_player && (i > -5 && i < 5) && (j > -5 && j < 5))
                {
                    played_player = true;
                    GameObject player = Instantiate(player_prefab, location, Quaternion.identity);

                    GameObject camera = Instantiate(camera_prefab, location, Quaternion.identity);
                    camera.GetComponent<FreeLookCam>().Target = player.transform;
                }
            }
        }
    }
}
