using Godot;
using System;

public class Player : KinematicBody {
    // Constants of motion for doing physics on... sorry for [Export] hell...
    [Export] private readonly float moveSpeed = 6.5f;
    [Export] private readonly float jumpForce = 17.5f;
    [Export] private readonly float runForce = 0.025f;
    [Export] private readonly float gravity = 22f;
    [Export] private readonly float maxFallSpeed = 30f;
    [Export] private readonly float xAirDamping = 0.95f;
    [Export] private readonly float xFloorDamping = 0.7f;
    //Apparently constants can't be exported to Godot's editor... huh...
    
    private Vector2 vel = Vector2.Zero;
    private bool facing_right = false;
    
    //TODO: Add reference to animation player for when graphics are finalised.


    public override void _PhysicsProcess(float delta) {
        //Positive values of move_dir indicate a move towards the right.
        int moveDir = 0;

        if (Input.IsActionPressed("move_right")) {
            moveDir++;
        } else if (Input.IsActionPressed("move_left")) {
            moveDir--;
        }

        if (moveDir != 0)
            vel.x = moveDir;
        
        //Jumping code
        bool justJumped = false;
        bool grounded = IsOnFloor();
        bool ceilinged = IsOnCeiling();
        bool walled = IsOnWall();
        
        vel.y -= gravity * delta;
        if (vel.y < -maxFallSpeed) {
            vel.y = -maxFallSpeed;
        }
        
        if (grounded)
        {
            vel.y = -0.01f;
            if (Input.IsActionPressed("jump"))
            {
                justJumped = true;
                vel.y = jumpForce;
            }
        }
            
        if (ceilinged)      // bang head on ceiling
            vel.y = 0f;

        if (walled)         // bump into wall
            vel.x = 0f;


        //This just moves the player along a vector... I'm sorry for declaring the vector at runtime but whatever...
        MoveAndSlide(new Vector3(moveSpeed * vel.x, vel.y, 0), new Vector3(0, 1, 0));
        
        // x damping - doesn't matter what moveDir is bc this will be overwritten next call if it's != 0
        vel.x *= grounded ? xFloorDamping : xAirDamping;
        vel.x = (float) Math.Round(vel.x, 4);

        // Flip the character. Probably not useful without graphics.
        // TODO: Fix flip functionality.
        if (moveDir < 0 && facing_right) {
            Flip();
        }
        if (moveDir > 0 && !facing_right) {
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
