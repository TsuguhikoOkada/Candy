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

        // Linqを使用したラムダ式で書いたコード↓

        colliders.Where(collider => Block.IsBlock(collider.gameObject)).ToList().ForEach(collider => Destroy(collider.gameObject));

        // ここまで↑

        // 修正前のコード↓

        /*foreach (Collider2D collider in colliders)
        {
            if (Block.IsBlock(collider.gameObject))
            {
                Destroy(collider.gameObject);
                
            }
        }*/

        // ここまで↑

        Destroy(gameObject);
    }
}