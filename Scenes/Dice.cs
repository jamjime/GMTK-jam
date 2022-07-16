using System;
using Godot;

public class Dice : RigidBody
{
    [Export] public readonly DiceNumber diceNumber = DiceNumber.One;

    private Effect[] effects;
    
    /* effect mapping for cube net, hopefully: ? I don't know how to implement this yet, but we'll figure it out
     * 0
     * 1 2 3 4
     * 5
     */

    public override void _Ready()
    {
        switch (diceNumber)
        {
            default:
            case DiceNumber.One:
                effects = new[]
                {
                    Effect.DoubleJump,
                    Effect.RotateClockwise
                };
                break;
        }

        for (int i = 0; i < effects.Length; i++)
        {
            Material mat = GetNode<MeshInstance>("DiceMesh").GetSurfaceMaterial(i);
            
            Image img = new Image();
            img.Load("res://Assets/effects.png");
            img = img.GetRect(new Rect2((int) effects[i] % 2, (int) effects[i] / 2, 64, 64));
                
            ImageTexture texture = new ImageTexture();
            texture.CreateFromImage(img);
            
            (mat as ShaderMaterial).SetShaderParam("albedo_texture", texture);
            //(mat as SpatialMaterial).AlbedoTexture = texture;

            GetNode<MeshInstance>("DiceMesh").SetSurfaceMaterial(i, mat);

            break;  // temp
        }
    }
    

    public enum DiceNumber
    {
        One, Two, Three
    }

    private enum Effect
    {
        DoubleJump,
        Unknown,
        RotateClockwise
    }
}
