using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundController : MonoBehaviour
{
    //We only scroll down

    List<Tilemap> tilemaps = new List<Tilemap>();
    public Tilemap environmentPrefab;
    public float scrollSpeed;

    const int INITIAL_TILEMAP_COUNT = 2;

    //private Tilemap[] environments;


    void Start()
    {
        //environments = GetComponentsInChildren<Tilemap>();

        //CACHE 3 TILEMAPS
        var offset = environmentPrefab.size.y * environmentPrefab.cellSize.y;
        for(int i = 0; i < INITIAL_TILEMAP_COUNT; i++)
        {
            var tilemap = Instantiate(environmentPrefab, transform);
            tilemap.transform.position = transform.position;
            tilemap.transform.position += Vector3.down * offset * i;
            tilemaps.Add(tilemap);
        }
    }

    void Update()
    {

        //Tracking
        List<Tilemap> removeTilemaps = new List<Tilemap>();
        float offset = environmentPrefab.size.y * environmentPrefab.cellSize.y;
        float endpoint = transform.position.y - (offset * INITIAL_TILEMAP_COUNT);

        foreach (var tilemap in tilemaps)
        {
            if(tilemap.transform.position.y < endpoint)
            {
                removeTilemaps.Add(tilemap);
                
            }
        }

        //Checkup
        foreach(var tilemap in removeTilemaps)
        {
            tilemap.transform.position = transform.position;
        }
        removeTilemaps.Clear();

        //Scrolling
        foreach (var tilemap in tilemaps)
        {

            tilemap.transform.position += Vector3.down * Time.deltaTime * scrollSpeed;
        }
    }
}
