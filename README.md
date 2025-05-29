# PUCPR - Collider Limiter

[About](#about) | [How to Install](#how-to-install) | [Contribute](#how-to-contribute)

## About

Collider Limiter is a Unity package that provides a powerful and flexible solution for limiting collisions in specific areas of your game. This tool is designed to help developers easily create and manage collision boundaries with precise control over their properties and behavior.

### Features
- ColliderLimiter Component
    - Configurable area size with built-in minimum size protection
    - Adjustable collider thickness
    - Selective side activation (top, bottom, left, right, front, back)
    - Automatic collider generation and positioning
    - Custom layer assignment for generated colliders
    - Comprehensive debug visualization tools
        - Area boundaries visualization
        - Forward direction indicator
        - Collider preview in wire/solid modes

- Plus Custom Attributes
    - EnumNamedArray for enum-controlled arrays
    - Layer selector for Unity layers

## How to Install

- Unity -> Window -> Package Manager  
- Click "+" at the top left corner  
- Add package from git URL  
- Insert `https://github.com/CRE-Tools/colliderlimiter.git`
- Add  
- Done

## How to Contribute

We follow the GitFlow workflow for this project:

1. Fork the repository
2. Create a new feature branch from `develop` branch
3. Make your changes
4. Commit your changes with clear commit messages
5. Submit a pull request targeting the `develop` branch

Note: All feature branches must be created from and merged back into the `develop` branch. Direct changes to `main` branch are not allowed.

For bug reports and feature requests, please open an issue in the repository.