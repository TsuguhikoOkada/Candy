using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bomb : MonoBehaviour
{
    void OnMouseDown()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        
        GetComponentInParent<BlockManager>().OnBlockClear(colliders.Length);

        colliders.Where(collider => Block.IsBlock(collider.gameObject)).ToList().ForEach(collider => Destroy(collider.gameObject));

        Destroy(gameObject);
    }
}
