using System;
using Godot;

public class Player : KinematicBody {
    // Modified Constant Values - I've played around with these and this
    // is what felt best to me. Feel free to modify to your liking.
    [Export] private float TARGET_FPS = 60; // Gaming moment...
    [Export] private float ACCELERATION = 8;
    [Export] private float MAX_SPEED = 64;
    [Export] private float FRICTION = 10;

    [Export]
    private float AIR_RESISTANCE = 1; // I've called this air resistance, but really it's just the stopping factor.

    [Export] private float GRAVITY = -4;
    [Export] private float JUMP_FORCE = 140;

    private Vector3 motion = Vector3.Zero;

    public override void _Ready() {
        //TODO: Graphics and Sprite-work
    }

    public override void _PhysicsProcess(float delta) {
        var x_input = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");

        // Defining horizontal motion
        if (x_input != 0) {
            //TODO: Play the running animation
            motion.x += x_input * ACCELERATION * delta * TARGET_FPS;
            motion.x = Mathf.Clamp(motion.x, -MAX_SPEED, MAX_SPEED);
            //TODO: Flip the lil guy
        }

        // Defining vertical motion
        motion.y += GRAVITY * delta * TARGET_FPS; // Gravity

        // Jumping - (Defying gravity)
        if (IsOnFloor()) {
            if (x_input == 0) motion.x = Mathf.Lerp(motion.x, 0, FRICTION * delta);

            if (Input.IsActionJustPressed("jump")) {
                motion.y = JUMP_FORCE;
                Console.WriteLine("Jump pressed");
            }
        }
        else {
            // TODO: Play the jump animation

            // DIRTY variable-esc jumping
            if (Input.IsActionJustReleased("jump") && motion.y > JUMP_FORCE / 2) {
                motion.y = JUMP_FORCE / 2;
                Console.WriteLine("Jump released");
            }

            if (x_input == 0) motion.x = Mathf.Lerp(motion.x, 0, AIR_RESISTANCE * delta);
        }

        motion = MoveAndSlide(new Vector3(motion), new Vector3(0, 1, 0));
    }
}