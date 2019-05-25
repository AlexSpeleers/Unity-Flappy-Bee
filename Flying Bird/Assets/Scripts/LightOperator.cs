using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOperator : MonoBehaviour
{
    Transform player;
    Transform blockGenerator;

    public FloatVariable darkness;
    int blockNumber;
    public float lightGenerated = .2f;

    public void SpawnAndSetBlockNumber(int blockNumber, Transform player, Transform blockGenerator)
    {
        this.blockNumber = blockNumber;
        this.player = player;
        this.blockGenerator = blockGenerator;

        Vector3 pos = transform.position;
        pos.x = player.position.x + 1.75f + blockNumber;
        pos.y = Random.Range(0.4f, 2.0f);
        transform.position = pos;
    }

    void EnableRendere()
    {
        GetComponent<Renderer>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<Renderer>().enabled = false;
            darkness.value -= lightGenerated;
            Invoke("EnableRenderer", 3f);
        }
        else if (collision.tag == "Cleaner")
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 pos = transform.position;
        pos.x = blockGenerator.position.x;
        pos.y = Random.Range(0.40f, 2.0f);

        transform.position = pos;
    }
}
