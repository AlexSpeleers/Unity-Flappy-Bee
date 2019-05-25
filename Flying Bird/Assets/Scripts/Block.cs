using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Transform blockGenerator;
    int blockNumber;
    bool smallBlock;

    public void SetBlockNumberAndSpawn(int blockNumber, Transform blockGenerator, bool smallBlock)
    {
        this.blockNumber = blockNumber;
        this.blockGenerator = blockGenerator;
        this.smallBlock = smallBlock;

        Vector3 pos = Vector3.zero;
        pos.x = Camera.main.transform.position.x + 1.25f + blockNumber;
        PlaceBlock(pos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Cleaner")
        {
            Move();
        }    
    }

    void Move()
    {
        Vector3 pos = transform.position;
        pos.x = blockGenerator.position.x;
        PlaceBlock(pos);
    }
    void PlaceBlock(Vector3 pos)
    {
        if (smallBlock)
        {
            if (blockNumber % 2 == 0)
                pos.y = Random.Range(0.40f, 0.8f);
            else
                pos.y = Random.Range(1.8f, 2.1f);
        }
        else
            if (blockNumber % 2 != 0)
            pos.y = Random.Range(0.40f, 0.8f);
        else
            pos.y = Random.Range(1.7f, 2.1f);
        transform.position = pos;
    }
}
