using Godot;
using System;

public class PausePopup : Popup
{
    public override void _Ready()
    {
        resumeButton = GetNode<Button>("ResumeButton");
        resumeButton.Connect("pressed", this, "Resume");

        exitButton = GetNode<Button>("ExitButton");
        exitButton.Connect("pressed", this, "ExitToDesktop");
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("pause"))
        {
            if (GetTree().Paused)
                Resume();
            else
                Pause();
        }
    }


    private void Pause()
    {
        GetTree().Paused = true;
        Show();
    }

    private void Resume()
    {
        GetTree().Paused = false;
        Hide();
    }

    private void ExitToDesktop()
    {
        GetTree().Quit();
    }


    private Button resumeButton;
    private Button exitButton;

}
