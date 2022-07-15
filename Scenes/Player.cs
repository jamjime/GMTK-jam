using Godot;
using System;

public class Player : KinematicBody {
    // Constants of motion for doing physics on... sorry for [Export] hell...
    [Export] int MOVE_SPEED = 5;
    [Export] int JUMP_FORCE = 12;
    [Export] float GRAVITY = 9.8f;
    [Export] int MAX_FALL_SPEED = 30;
    
    //Apparently constants can't be exported to Godot's editor... huh...
    
    //Current velocity on the Y-Axis... obviously.
    private float y_velo = 0;
    private bool facing_right = false;
    
    //TODO: Add reference to animation player for when graphics are finalised.


    public override void _PhysicsProcess(float delta) {
        //Positive values of move_dir indicate a move towards the right.
        var move_dir = 0;

        if (Input.IsActionPressed("move_right")) {
            move_dir++;
        } else if (Input.IsActionPressed("move_left")) {
            move_dir--;
        }
        
        //This just moves the player along a vector... I'm sorry for declaring the vector at runtime but whatever...
        MoveAndSlide(new Vector3(move_dir * MOVE_SPEED, y_velo, 0), new Vector3(0, 1, 0));
        
        //Jumping code
        var justJumped = false; // Will be used for animation functionality...
        var grounded = IsOnFloor();
        y_velo -= GRAVITY * delta;

        if (y_velo < -MAX_FALL_SPEED) {
            y_velo = -MAX_FALL_SPEED;
        }

        if (grounded) {
            y_velo = -0.1f;
            if (Input.IsActionPressed("jump")) {
                y_velo = JUMP_FORCE;
                justJumped = true;
            }
        }
        
        // Flip the character. Probably not useful without graphics.
        // TODO: Fix flip functionality.
        if (move_dir < 0 && facing_right) {
            Flip();
        }

        if (move_dir > 0 && !facing_right) {
            Flip();
        }
        
        // TODO: Animation code.
    }

    public void Flip() {
        //TODO: This will need to be updated after graphics are introduced.
        //var mesh = GetNode<MeshInstance>("CHANGEGRAPHICS");
        //mesh.RotationDegrees.y *= -1; // Rotates 180 degrees
        facing_right = !facing_right;
    }
    
    public override void _Ready()
    {
        
    }


}
