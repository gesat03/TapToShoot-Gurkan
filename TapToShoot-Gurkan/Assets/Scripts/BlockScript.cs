using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField]
    Material[] mats;

    internal int blockPlacementNumber;

    internal bool hasColor;
    
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

        hasColor = true;

        this.transform.GetChild(0).gameObject.tag = "ColorBlock";
    }

    public void AddingForceAfterImpact()
    {
        hasColor = false;

        this.GetComponent<Rigidbody>().isKinematic = false;

        this.GetComponent<Rigidbody>().useGravity = true;

        this.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(3, 6)), ForceMode.Impulse);

        FindObjectOfType<SceneManager>().colorfulBlockCounter--;

        Destroy(this.gameObject, 2);
    }
}
