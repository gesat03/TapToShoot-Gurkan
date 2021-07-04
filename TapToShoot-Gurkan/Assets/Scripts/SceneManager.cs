using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject blockContainerObject;

    [Range(1, 5)]
    public int wallRowCount;
    [Range(1, 9)]
    public int wallColumnCount;
    [Range(1, 10)]
    public int randomRange;

    internal List<GameObject> blockList;

    Vector3 touchPosWorld;
    TouchPhase touchPhase = TouchPhase.Ended;


    private void Start()
    {
        InitializationFunction();
    }

    private void Update()
    {
        TouchDetect();
    }

    public void InitializationFunction()
    {
        blockList = new List<GameObject>();

        GeneratingBlocks();
    }


    private void GeneratingBlocks()
    {
        float tileSize = blockPrefab.transform.localScale.x + 0.1f;

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
            }
        }

        void ParentFrame(float _tileSize)
        {
            float gridW = wallRowCount * _tileSize;
            float gridH = wallColumnCount * _tileSize;

            blockContainerObject.transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
        }
    }

    public void TouchDetect()
    {
//#if !UNITY_EDITOR
//        if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
//        {
//            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

//            RaycastHit hit;

//            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);

//            if (Physics.Raycast(ray, out hit))
//            {
//                Debug.Log(hit.transform.name);
//                if (hit.collider != null)
//                {
//                    GameObject touchedObject = hit.transform.gameObject;

//                    Debug.Log("Touched " + touchedObject.transform.name);
//                }
//            }
//        }
//#else
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {
                    GameObject touchedObject = hit.transform.gameObject;

                    Debug.Log("Touched " + touchedObject.GetComponent<BlockScript>().blockPlacementNumber);
                }
            }
        }
        //#endif
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