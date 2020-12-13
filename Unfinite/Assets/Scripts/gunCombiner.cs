using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunCombiner : MonoBehaviour
{

    //public Texture2D blank;
    //public Texture2D stock;
    //public Texture2D scope;
    //public Texture2D barrel;
    //public Texture2D mag;

    // Start is called before the first frame update
    void Start()
    {
        //TestCombineParts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void CombineParts(Part stock, Part[] rest)
    //{
    //    Texture2D[] rest = { mag, barrel, scope };

    //    int[] ax = { 1, 0, 2, };
    //    int[] ay = { 6, 7, 12, };
    //    int[] bx = { 2, 10, 11, };
    //    int[] by = { 9, 1, 0, };

    //    Texture2D temp = stock;
    //    for (int i = 0; i < ax.Length; i++)
    //    {
    //        ReturnPart ret = createNewPart(temp, rest[i], ax[i], ay[i], bx[i], by[i]);
    //        print(ret.L + " " + ret.D);
    //        for (int j = i + 1; j < ax.Length; j++)
    //        {
    //            ax[j] = ax[j] + ret.L;
    //            ay[j] = ay[j] + ret.D;
    //        }
    //        temp = ret.T;
    //    }

    //    GameObject g = GameObject.Find("Cube");
    //    SpriteRenderer s = g.GetComponent<SpriteRenderer>();
    //    Sprite sp = Sprite.Create(temp, new Rect(0.0f, 0.0f, temp.width, temp.height), new Vector2(0.5f, 0.5f), 100.0f);
    //    s.sprite = sp;
    //    print(s.sprite);
    //}

    void TestCombineParts(Texture2D mag, Texture2D barrel, Texture2D scope, Texture2D stock)
    {
        Texture2D[] rest = { mag, barrel, scope };

        int[] ax = { 1, 0, 2, };
        int[] ay = { 6, 7, 12, };
        int[] bx = { 2, 10, 11, };
        int[] by = { 9, 1, 0, };

        Texture2D temp = stock;
        for (int i = 0; i < ax.Length; i++)
        {
            ReturnPart ret = createNewPart(temp, rest[i], ax[i], ay[i], bx[i], by[i]);
            print(ret.L + " " + ret.D);
            for (int j = i + 1; j < ax.Length; j++)
            {
                ax[j] = ax[j] + ret.L;
                ay[j] = ay[j] + ret.D;
            }
            temp = ret.T;
        }

        GameObject g = GameObject.Find("Cube");
        SpriteRenderer s = g.GetComponent<SpriteRenderer>();
        Sprite sp = Sprite.Create(temp, new Rect(0.0f, 0.0f, temp.width, temp.height), new Vector2(0.5f, 0.5f), 100.0f);
        s.sprite = sp;
        print(s.sprite);
    }

    public struct ReturnPart
    {
        public ReturnPart(int l, int r, int d, int u, Texture2D tex)
        {
            L = l;
            R = r;
            D = d;
            U = u;
            T = tex;
        }

        public int L { get; }
        public int R { get; }
        public int D { get; }
        public int U { get; }
        public Texture2D T { get; }
    }

    ReturnPart createNewPart(Texture2D a, Texture2D b, int ax, int ay, int bx, int by)
    {
        // a bunch of janky shit to get the correct size and coords
        int cornerx = ax - bx;
        int cornery = ay - by;

        int leftpx = cornerx < 0 ? -cornerx : 0;
        int downpx = cornery < 0 ? -cornery : 0;

        int rightpx = cornerx + b.width  > a.width  ? cornerx + b.width  - a.width  : 0;
        int toppx   = cornery + b.height > a.height ? cornery + b.height - a.height : 0;

        Texture2D temp = new Texture2D(a.width + leftpx + rightpx, a.height + downpx + toppx);
        // set texture to clear
        for (int y = 0; y < temp.height; y++)
        {
            for (int x = 0; x < temp.width; x++)
            {
                temp.SetPixel(x, y, Color.clear);
            }
        }
        // write in base texture
        for (int y = 0; y < a.height; y++)
        {
            for (int x = 0; x < a.width; x++)
            {
                temp.SetPixel(x + leftpx, y + downpx, a.GetPixel(x, y));
            }
        }
        // write in new texture
        for (int y = 0; y < b.height; y++)
        {
            for (int x = 0; x < b.width; x++)
            {
                Color newLayer = b.GetPixel(x, y);
                if (newLayer.a != 0) 
                {
                    temp.SetPixel(x + cornerx + leftpx, y + cornery + downpx, newLayer);
                }
            }
        }
        temp.Apply();
        temp.filterMode = FilterMode.Point;

        return new ReturnPart(leftpx, rightpx, downpx, toppx, temp);
    }
}