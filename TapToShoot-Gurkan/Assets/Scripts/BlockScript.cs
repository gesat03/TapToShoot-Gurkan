using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    internal int blockPlacementNumber;

    [SerializeField]
    Material[] mats;
    


    public void BlockPos(Vector2 pos)
    {
        this.gameObject.transform.position = pos;
    }

    public void ChangeMaterial(BlockColor color)
    {
        switch (color)
        {
            case BlockColor.Red:
                this.gameObject.GetComponent<MeshRenderer>().material = mats[(int)color];
                break;
            case BlockColor.Blue:
                this.gameObject.GetComponent<MeshRenderer>().material = mats[(int)color];
                break;
            case BlockColor.Yellow:
                this.gameObject.GetComponent<MeshRenderer>().material = mats[(int)color];
                break;
            case BlockColor.Orange:
                this.gameObject.GetComponent<MeshRenderer>().material = mats[(int)color];
                break;
            case BlockColor.Green:
                this.gameObject.GetComponent<MeshRenderer>().material = mats[(int)color];
                break;
            case BlockColor.Purple:
                this.gameObject.GetComponent<MeshRenderer>().material = mats[(int)color];
                break;
            case BlockColor.Gray:
                this.gameObject.GetComponent<MeshRenderer>().material = mats[(int)color];
                break;
            default:
                break;
        }
    }
}
