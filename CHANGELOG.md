## [1.0.2] - 2025-06-02

### Updated
- Readme updated to the new template version
- UserManual base to implement (content miss)
- bug_report issue template to work with Unity example

### Added
- Contributing file


## [1.0.1] - 2025-05-29

### Changed
- Updated package description in package.json
- Enhanced documentation in README.md:
    - Comprehensive About section
    - Detailed feature list with hierarchical structure
    - GitFlow workflow requirements for contributions

### Added
- Detailed features documentation:
    - ColliderLimiter component capabilities
    - Custom attributes functionality
    - Debug visualization tools
    - CubeSides enumeration usage

## [1.0.0] - 2025-05-27

### Added

 - <b>EnumNamedArray</b>: (Custom attribute) Array controlled by an enum.

 - <b>Layer</b>: (Custom attribute) Exposed layer selector for Unity layers.

 - <b>ColliderLimiter</b>: Main component for limiting collisions in specific areas
      - Configurable area size with minimum size protection
      - Customizable collider thickness
      - Selective side activation (top, bottom, left, right, front, back)
      - Automatic collider generation and positioning
      - Layer assignment for generated colliders
      - Debug visualization tools:
        - Area boundaries visualization
        - Forward direction indicator
        - Collider preview (wire/solid modes)

- <b>CubeSides</b>: Enumeration for cube face selection (top, bottom, left, right, front, back)


## [0.0.1] - 2025-05-26

### Added

- This CHANGELOG.
- README.
- LICENSE
- package.json file that contains the configuration needed to use the package in Unity