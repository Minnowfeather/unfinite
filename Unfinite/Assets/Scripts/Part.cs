using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Part
{
    
    public Part(Texture2D textureOfThePartThatThisStructRepresents, Stats stats, int[] x, int[] y){ 
        this.stats = stats;
        this.textureOfThePartThatThisStructRepresents = textureOfThePartThatThisStructRepresents;
        this.x = x;
        this.y = y;
    }
    public int[] x { get; }
    public int[] y { get; }
    public Stats stats { get; }
    public Texture2D textureOfThePartThatThisStructRepresents { get; }
}
