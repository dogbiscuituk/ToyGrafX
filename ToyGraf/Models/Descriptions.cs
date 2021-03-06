﻿namespace ToyGraf.Models
{
    internal static class Descriptions
    {
        internal const string
            BackgroundColour = "The colour of the background.",
            Camera = "The 3D position and 3-axis rotation (in degrees) of the camera in this scene.",
            CameraView = "The camera view matrix for the scene.",
            Description = "A description for this trace.",
            FPS = "Frames per second: a cap on this scene's rendering frequency.",
            GLInfo = "Version information about this OpenGL implementation.",
            GLInfo_Extensions = "The extensions supported by the GL implementation for the current context.",
            GLInfo_Major = "The major version number of the OpenGL API supported by the current context.",
            GLInfo_Minor = "The minor version number of the OpenGL API supported by the current context.",
            GLInfo_Number = @"The version or release number of OpenGL API supported by the current context. Begins with a version number using one of these forms:
major_number.minor_number
major_number.minor_number.release_number
Vendor-specific information may follow the version number. Its format depends on the implementation, but a space always separates the version number and the vendor-specific information.",
            GLInfo_Renderer = "The name of the renderer. This name is typically specific to a particular configuration of a hardware platform",
            GLInfo_Shader = @"The version or release number of the shading language (GLSL). Begins with a version number using one of these forms:
major_number.minor_number
major_number.minor_number.release_number
Vendor-specific information may follow the version number. Its format depends on the implementation, but a space always separates the version number and the vendor-specific information.",
            GLInfo_Vendor = "The name of the company responsible for the OpenGL API supported by the current context.",
            GLMode = "Information about the current graphics mode.",
            GLMode_AccumColourFormat = "The number of bits per pixel in each accumulator colour channel.",
            GLMode_Buffers = "The number of buffers associated with this display mode.",
            GLMode_ColourFormat = "The number of bits per pixel in each colour channel.",
            GLMode_Depth = "The number of bits in the depth buffer.",
            GLMode_Index = "The platform-specific index for the current graphics mode.",
            GLMode_Samples = "The number of Full Screen Anti-Aliasing (FSAA) samples used.",
            GLMode_Stencil = "The number of bits in the stencil buffer.",
            GLMode_Stereo = "Indicates whether this display mode is stereoscopic 3D.",
            GLTargetVersion = @"Shaders should declare the version of the language they are written to. The language version a shader is written to is specified by #version number profile_opt, where number must be a version of the language. 
The directive #version 460 is required in any shader that uses version 4.60 of the language. Any number representing a version of the language a compiler does not support will cause a compile-time error to be generated. 
Version 1.10 of the language does not require shaders to include this directive, and shaders that do not include a #version directive will be treated as targeting version 1.10. 
If the optional profile argument is provided, it must be the name of an OpenGL profile. Currently, there are three choices: core. compatibility, and es. A profile argument can only be used with version 150 or greater. 
If no profile argument is provided and the version is 150 or greater, the default is core. If version 300 or 310 is specified, the profile argument is not optional and must be es, or a compile-time error results. 
The #version directive must occur in a shader before anything else, except for comments and white space.",
            GPUCode = "The full source code of the GPU program.",
            GPULog = "The list of diagnostic, warning and error messages generated by the most recent GPU program compilation.",
            GPUStatus = "The status of the most recent GPU program compilation.",
            Location = "A vector representing the location of the trace in world co-ordinates.",
            Maximum = "A vector representing the upper limit along each domain or range axis.",
            Minimum = "A vector representing the lower limit along each domain or range axis.",
            Orientation = "A rotation representing the orientation of the trace in world co-ordinates (degrees).",
            Pattern = "The pattern applied to the sequence, grid or lattice of computed points.",
            Projection = "The projection for the scene.",
            ProjectionMatrix = "The projection matrix for the scene.",
            Scale = "A vector representing the relative size of the trace along each axis.",
            Shader1Vertex = @"The vertex processor is a programmable unit that operates on incoming vertices and their associated data. Compilation units written in the OpenGL Shading Language to run on this processor are called vertex shaders.
When a set of vertex shaders are successfully compiled and linked, they result in a vertex shader executable that runs on the vertex processor.
The vertex processor operates on one vertex at a time. It does not replace graphics operations that require knowledge of several vertices at a time.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].",
            Shader2TessControl = @"The tessellation control processor is a programmable unit that operates on a patch of incoming vertices and their associated data, emitting a new output patch. Compilation units written in the OpenGL Shading Language to run on this processor are called tessellation control shaders.
When a set of tessellation control shaders are successfully compiled and linked, they result in a tessellation control shader executable that runs on the tessellation control processor.
The tessellation control shader is invoked for each vertex of the output patch. Each invocation can read the attributes of any vertex in the input or output patches, but can only write per-vertex attributes for the corresponding output patch vertex.
The shader invocations collectively produce a set of per-patch attributes for the output patch. After all tessellation control shader invocations have completed, the output vertices and per-patch attributes are assembled to form a patch to be used by subsequent pipeline stages.
Tessellation control shader invocations run mostly independently, with undefined relative execution order. However, the built-in function barrier() can be used to control execution order by synchronizing invocations, effectively dividing tessellation control shader execution into a set of phases.
Tessellation control shaders will get undefined results if one invocation reads a per-vertex or per-patch attribute written by another invocation at any point during the same phase, or if two invocations attempt to write different values to the same per-patch output in a single phase.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].",
            Shader3TessEvaluation = @"The tessellation evaluation processor is a programmable unit that evaluates the position and other attributes of a vertex generated by the tessellation primitive generator, using a patch of incoming vertices and their associated data.
Compilation units written in the OpenGL Shading Language to run on this processor are called tessellation evaluation shaders.
When a set of tessellation evaluation shaders are successfully compiled and linked, they result in a tessellation evaluation shader executable that runs on the tessellation evaluation processor.
Each invocation of the tessellation evaluation executable computes the position and attributes of a single vertex generated by the tessellation primitive generator.
The executable can read the attributes of any vertex in the input patch, plus the tessellation coordinate, which is the relative location of the vertex in the primitive being tessellated. The executable writes the position and other attributes of the vertex.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].",
            Shader4Geometry = @"The geometry processor is a programmable unit that operates on data for incoming vertices for a primitive assembled after vertex processing and outputs a sequence of vertices forming output primitives.
Compilation units written in the OpenGL Shading Language to run on this processor are called geometry shaders.
When a set of geometry shaders are successfully compiled and linked, they result in a geometry shader executable that runs on the geometry processor.
A single invocation of the geometry shader executable on the geometry processor will operate on a declared input primitive with a fixed number of vertices.
This single invocation can emit a variable number of vertices that are assembled into primitives of a declared output primitive type and passed to subsequent pipeline stages.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].",
            Shader5Fragment = @"The fragment processor is a programmable unit that operates on fragment values and their associated data. Compilation units written in the OpenGL Shading Language to run on this processor are called fragment shaders.
When a set of fragment shaders are successfully compiled and linked, they result in a fragment shader executable that runs on the fragment processor.
A fragment shader cannot change a fragment's (x, y) position. Access to neighboring fragments is not allowed.
The values computed by the fragment shader are ultimately used to update framebuffer memory or texture memory, depending on the current OpenGL state and the OpenGL command that caused the fragments to be generated.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].",
            Shader6Compute = @"The compute processor is a programmable unit that operates independently from the other shader processors. Compilation units written in the OpenGL Shading Language to run on this processor are called compute shaders.
When a set of compute shaders are successfully compiled and linked, they result in a compute shader executable that runs on the compute processor.
A compute shader has access to many of the same resources as fragment and other shader processors, including textures, buffers, image variables, and atomic counters. It does not have any predefined inputs nor any fixed-function outputs.
It is not part of the graphics pipeline and its visible side effects are through changes to images, storage buffers, and atomic counters.
A compute shader operates on a group of work items called a work group. A work group is a collection of shader invocations that execute the same code, potentially in parallel.
An invocation within a work group may share data with other members of the same work group through shared variables and issue memory and control barriers to synchronize with other members of the same work group.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].",
            StripCount = "A vector representing the number of discrete strips into which the trace is divided along each axis.",
            Title = "A title for this scene.",
            TraceList = "A list of the traces in this scene.",
            Transform = "The transformation matrix of the trace.",
            VaoID = "The integer ID of the Vertex Array",
            VaoVertexCount = "The number of vertices in the Vertex Array.",
            VboIndexID = "The integer ID of the Index Buffer",
            VboVertexID = "The integer ID of the Vertex Buffer",
            Visible = "Take a wild guess.",
            VSync = "Indicates whether GLControl updates are synced to the monitor's refresh rate.";
    }
}
