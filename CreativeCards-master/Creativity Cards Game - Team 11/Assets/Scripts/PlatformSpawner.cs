using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    public GameObject[] platforms;
    public List<GameObject> spawnedPlatforms = new List<GameObject>();
    //public int numberOfPlatforms;
    public float SceneWidth;
    private int index;

    [SerializeField]
    private Transform player;
    private float currentPlayerHeight;

    [Header("Platform X Bounds")]
    [SerializeField]
    private float minPositionPlatformX;
    [SerializeField]
    private float maxPositionPlatformX;

    [Header("Default Platform Heights")]
    [SerializeField]
    private int startHeight;
    [SerializeField]
    private int maxHeight;
    [SerializeField]
    private float platformDistance;
    [SerializeField]
    private float extraSpawnDistance;
    private bool canSpawn;

    private void Start()
    {
        canSpawn = true;
        GeneratePlatforms(startHeight, maxHeight, platformDistance);
    }

    private void Update()
    {
        currentPlayerHeight = player.position.y;
        ComparePlayerDistance(currentPlayerHeight, spawnedPlatforms[spawnedPlatforms.Count - 1].transform.position.y, extraSpawnDistance);
    }

    private void ComparePlayerDistance(float playerHeight, float lastPlatformHeight, float extraDistance)
    {
        float checkHeight = lastPlatformHeight - extraDistance;
        if (checkHeight <= playerHeight && canSpawn)
        {
            canSpawn = false;
            int highestPlatformHeight = Mathf.RoundToInt(spawnedPlatforms[spawnedPlatforms.Count - 1].transform.position.y);
            GeneratePlatforms(Mathf.RoundToInt(highestPlatformHeight + platformDistance), maxHeight + highestPlatformHeight, platformDistance);  
        }
    }

     /// <summary>
     /// Spawns the platforms using a list of heights made in GenerateHeightList(...)
     /// once it has spawned it removes that height option from the list so that no
     /// two platforms spawn on the same height.
     /// 
     /// You'll want to use this function and provide it the starting height of the new 
     /// 'chunk' to load as well as the highest point you want to render it to until the
     /// next chunk.
     ///
     /// You'll have to implement a script that uses the function below every so often 
     /// for performance purposes.
     /// </summary>
     /// <param name="startHeight"></param>
     /// <param name="maxHeight"></param>
     /// <param name="platformDistance"></param>
    private void GeneratePlatforms(int startHeight, int maxHeight, float platformDistance)
    {
        List<float> availableHeights = GenerateHeightList(startHeight, maxHeight, platformDistance);

        for (int i = 0; i < availableHeights.Count - 1; i++)
        {
            float height = availableHeights[i];
            //Removing it ensures it will only be used once
            availableHeights.Remove(i);

            Vector2 randomHeight = new Vector2(UnityEngine.Random.Range(minPositionPlatformX, maxPositionPlatformX), height);
            SpawnPlatforms(randomHeight);
        }

        print(canSpawn);
        canSpawn = true;
    }

    //Generates a list using a minimum and maximum height. It also uses a distance to state how many platform positions are between
    private List<float> GenerateHeightList(int startHeight, int maxHeight, float platformDistance)
    {
        //Declaring an empty list of floats
        List<float> availableHeights = new List<float>();
        for (float i = startHeight; i < maxHeight; i+=platformDistance)
        {
            availableHeights.Add(i);
        }

        return availableHeights;
    }

    //Deals with just the Platform Instantiation using a position
    private void SpawnPlatforms(Vector2 position)
    {
        spawnedPlatforms.Add(Instantiate(platforms[Random.Range(0, platforms.Length)], position, Quaternion.identity));
    }
}
