# GMTK Game Jam Entry - jam.jime

![GMTK Banner from Itch.io](https://img.itch.zone/aW1nLzk0NTkwMDcucG5n/original/ZK4O1T.png)

> 🎲 _The theme is '**Roll of the Dice**'_ 🎲

The following content has been lifted from the Game Design document and modified slightly:

## Basic Gameplay
- [X] Side-view platformer
- [ ] Hand-designed _metroidvania_-type levels with
  - [ ] a different **puzzle/challenge** in each level
- [ ] Dice
  - [ ] A number of dice are _collectable_ throughout the game.
  - [ ] Each die has a variety of _effects_. (Limited for time-scope to three)
    - 👟 - Movement/Agility
    - ⛰ - Environmental
    - 👾 - Enemy/NPC Effects
  - [ ] Dice can be selected through a _selection screen_
- [ ] Enemies that try to catch(?) the player
  - [ ] Slowed game-speed when selecting dice.

## Visuals
- 2.5D Pixel Art aesthetic with
- steampunk vibes set in a
- submarine


| Screenshots | Description |
|--|--|
| **TODO:** Add images | This is a description of the images |

---

For more information, please consult the Google Doc pinned in the _programming_ channel of the Discord.

---
# Technical Information
The following is a basic reference for some of the techincal stuff in the project that I'd like to keep track of.

### CI/CD Workflow
The workflow has been set-up and shouldn't require any special attention or changes. The build is automatically sent to my Raspberry Pi, functioning as an onsite backup. The git repo is mirrored to my offline repo every 15 minutes.

#### CI/CD Support
This template has support for tests and CI/CD integration.
- **To add tests**: Add tests to `tests/unit` or `tests/integration`. Only filenames starting with `test_` get tested!
- **To build project:** When `master` gets a commit or a PR, the CI will automatically build the project using the Godot-CLI for `Windows`, `Mac`, `Linux` and `WebGL`!

#### Optional modifications to CI/CD
* Modify `.pre-commit-config.yml` and comment out pre-commit hooks you don't want to run.
* Modify `.gutconfig.json` to change how gut runs.
* Modify the `GODOT_VERSION` env_var in `.gut.sh` to match your preferred version of Godot.
* Modify the build status images at the top of this README to point to your build status instead of the template's
