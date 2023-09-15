using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SpawnObjects : MonoBehaviour
{
    public GameObject TopBorder;
    public GameObject BottomBorder;
    public GameObject LeftBorder;
    public GameObject RightBorder;

    public UIHandler UIScore;

    public GameObject player;

    public GameObject EnemyPrefab;

    public GameObject storeEnemy;

    public int totalFirstEnemy = 10;
    public int FirstWaveGoal = 20;

    public int totalSecondEnemy = 5;
    public int SecondWaveGoal = 40;

    public GameObject firstEnemy;
    public GameObject secondEnemy;

    public GameObject star;

    public GameObject EnemyLineObject;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawnManagment();
        spawnStars();

        


    }

    private void EnemySpawnManagment()
    {
        
        if (UIScore.currentScore > SecondWaveGoal)
        {
            EnemyWaves("SecondEnemy", totalSecondEnemy, SecondWaveGoal, secondEnemy);
        }

        if (UIScore.currentScore < SecondWaveGoal)
        {
            EnemyWaves("Enemy", totalFirstEnemy, FirstWaveGoal, firstEnemy);
        }


        
        
        // second enemy


        EnemyLine();

        
    }

    void InstantiateEnemy(GameObject enemyPreFab)
    {




        // first we randomize bwtween 2 borders
        Vector3 randomPositionBlocks;
        int xEnemy = (int)Random.Range(LeftBorder.transform.position.x, RightBorder.transform.position.x);
        int yEnemy = (int)Random.Range(TopBorder.transform.position.y, BottomBorder.transform.position.y);
        randomPositionBlocks = new Vector3((int)xEnemy, (int)yEnemy);


        //we then add the value to our player position

        float targetXPos = player.transform.position.x + xEnemy;
        float targetYPos = player.transform.position.y + yEnemy;

        

        // we create bools to check if they are in the area we are looking for 

        bool xIsInsideBorders = targetXPos < RightBorder.transform.position.x && targetXPos > LeftBorder.transform.position.x;
        bool yIsInsideBorders = targetYPos < TopBorder.transform.position.y && targetYPos > LeftBorder.transform.position.y;

        // we run a while loop to randomize numbers until we find those who are inside our borders
        while (!xIsInsideBorders)
        {
            xEnemy = (int)Random.Range(LeftBorder.transform.position.x, RightBorder.transform.position.x);
            targetXPos = player.transform.position.x + xEnemy;
            xIsInsideBorders = targetXPos < RightBorder.transform.position.x && targetXPos > LeftBorder.transform.position.x;
        }

        while (!yIsInsideBorders)
        {
            yEnemy = (int)Random.Range(LeftBorder.transform.position.y, RightBorder.transform.position.y);
            targetYPos = player.transform.position.y + yEnemy;
            yIsInsideBorders = targetYPos < TopBorder.transform.position.y && targetYPos > BottomBorder.transform.position.y;


        }


        // we instilate our values and instiantiate
        randomPositionBlocks = new Vector3((int)xEnemy, (int)yEnemy);

       Instantiate(enemyPreFab, randomPositionBlocks, Quaternion.identity, storeEnemy.transform);

        

    }

    void spawnStars()
    {
        float Xstar = (float)Random.Range(LeftBorder.transform.position.x, RightBorder.transform.position.x);
        float Ystar = (float)Random.Range(TopBorder.transform.position.y, BottomBorder.transform.position.y);

        Vector2 RandomizeStar = new Vector2(Xstar, Ystar);

        var starObject = Instantiate(star, RandomizeStar, gameObject.transform.rotation, transform);
        Destroy(starObject.gameObject, 1);
    }

    void EnemyLine()
    {
        Vector2 enemyPosition;

        //for (int i = 0; i < 10; i++)
        //{
        //    enemyPosition = new Vector2(i, 5);

        //    Instantiate(EnemyLineObject, enemyPosition, gameObject.transform.rotation);
        //}
        
    }

    void EnemyWaves(string EnemyTag, int MaxEnemy, int NextLevelGoal, GameObject enemyObject)
    {
        GameObject[] find;
        int currentEnemies;

        

        bool spawnEnemies = false;

        find = GameObject.FindGameObjectsWithTag(EnemyTag);
        currentEnemies = find.Length;





        // our first enemy
        if (currentEnemies > MaxEnemy)
        {
            spawnEnemies = false;

        }
        if (currentEnemies < MaxEnemy)
        {
            spawnEnemies = true;
        }

     
        if (spawnEnemies)
        {
            InstantiateEnemy(enemyObject);
        }
    }

}


