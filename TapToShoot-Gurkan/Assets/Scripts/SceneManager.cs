using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [Space]
    [Header("Block")]
    public GameObject blockPrefab;
    public GameObject blockContainerObject;
    [Space]
    [Header("Projectile")]
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public GameObject shooterObj;
    [Space]
    [Header("Grid Properties")]
    [Range(1, 5)]
    public int wallRowCount;
    [Range(1, 9)]
    public int wallColumnCount;
    [Range(1, 10)]
    public int randomRange;
    [Range(1, 10)]
    public int bombChance;

    internal List<GameObject> blockList;

    internal int colorfulBlockCounter;

    internal bool gameStarted;

    GameObject touchedObject;

    

    public void InitializationFunction()
    {
        blockList = new List<GameObject>();

        gameStarted = true;

        GeneratingBlocks();
    }

    public void LevelCompletedSM()
    {
        gameStarted = false;

        foreach (var item in blockList)
        {
            Destroy(item);
        }
    }

    private void GeneratingBlocks()
    {
        float tileSize = blockPrefab.transform.localScale.x + 0.1f;

        blockContainerObject.transform.position = Vector3.zero;

        colorfulBlockCounter = 0;

        for (int col = 0; col < wallColumnCount; col++)
        {
            for (int row = 0; row < wallRowCount; row++)
            {
                blockList.Add(Instantiate(blockPrefab, blockContainerObject.transform));

                float posX = row * tileSize;
                float posY = col * -tileSize;

                int placementNumber = (col * wallRowCount) + row;

                blockList[placementNumber].GetComponent<BlockScript>().BlockPos(new Vector2(posX, posY));

                blockList[placementNumber].GetComponent<BlockScript>().blockPlacementNumber = placementNumber;

                RandomBlockColor(placementNumber);
            }
        }

        ParentFrame(tileSize);

        void RandomBlockColor(int blockNum)
        {
            if(Random.Range(0, 10) >= 10 / randomRange)
            {
                blockList[blockNum].GetComponent<BlockScript>().ChangeMaterial((BlockColor)Random.Range(0, 6));

                colorfulBlockCounter++;
            }
        }

        void ParentFrame(float _tileSize)
        {
            float gridW = wallRowCount * _tileSize;
            float gridH = wallColumnCount * _tileSize;

            blockContainerObject.transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
        }
    }

    public void ChangeBlocksColor()
    {
        foreach (var item in blockList)
        {
            if(item.gameObject != null)
            {
                if (item.GetComponent<BlockScript>().hasColor)
                {
                    item.GetComponent<BlockScript>().ChangeMaterial((BlockColor)Random.Range(0, 6));
                }
            }
        }
    }

    public void ProjectileMotion()
    {
        if (gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject.tag == "ColorBlock")
                    {
                        touchedObject = hit.transform.gameObject;

                        Debug.Log("Touched " + touchedObject.GetComponent<BlockScript>().blockPlacementNumber);

                        if ((int)Random.Range(0, 10) < bombChance)
                        {
                            InstatiateProjectileAndFire(bombPrefab, touchedObject.transform);
                        }
                        else
                        {
                            InstatiateProjectileAndFire(bulletPrefab, touchedObject.transform);
                        }

                        Debug.Log(colorfulBlockCounter);
                    }
                }

                void InstatiateProjectileAndFire(GameObject prefab, Transform destination)
                {
                    GameObject bullet = Instantiate(prefab, shooterObj.transform.position, Quaternion.identity);

                    bullet.GetComponent<Projectiles>().ProjectileFire(destination);
                }
            }
        }
    }


}


public enum BlockColor
{
    Red,
    Blue,
    Yellow,
    Orange,
    Green,
    Purple,
    Gray
} 