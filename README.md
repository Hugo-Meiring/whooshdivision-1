# OcuViz

##About
OcuViz is a platform for the visualisation of data in a virtual 3D space to allow users to conceptualise large numbers more accurately and naturally. Leveraging the power of VR we are able to create awe-inspiring and immersive scenes for users to experience. As well as, allowing users to create their own scenes through either modular CSV files which are interpreted into 3D scenes or a simplified editor without requiring the user having to be a graphics experts.

# Requirements

## Input format
You can decide on what the input format must be but the following requirements must be met:

* The scene description and input data must be different input files
* CSV must be one of the input data formats
* An editor must be provided to load and save a scene decription file

## Data format
* The system must at least support 2D input data, 3D (With time etc.) or more may be supported
* Rows in the input data will be linked to entities.
* Entities will have properties (like the size of the model) and this will be linked to either static values or columns in the input data.

## Scene format
* Required
    - Specifing placement of entities in 3D
        + Rows
        + Randomly
        + Specified by data
    - Background
        + Solid colour
* Optional
    - Placing entities on globe/map based on location info
    - Animation
        + Physics-based
        + Described by data (speed/velocity, position over time)
        + Flow (liquid flowing out of pipe)
    - Background
        + Cubemap
    - Time-based simulations
        + Ex. Populations of countries over time
        + Time of day
    - Leap Motion integration (we will provide the hardware)

## Models
* Required
    - Each entity will have an associated model
    - Basic shapes must be supported
        + Sphere
        + Cylinder
        + Rectangular Prism
        + Texturing and colouring
    - Import of various types of models should be supported
        + OBJ must be supported
        + Other formats are allowed to be supported
* Optional
    - Animated models
    - Colouring/tinting of models based on data
