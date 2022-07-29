using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public long id;
    public ItemTag tag;
    public int count;

    public Item(long id, ItemTag tag, int count)
    {
        this.id = id;
        this.tag = tag;
        this.count = count;
    }
}
