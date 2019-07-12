#version 330 core
layout (location = 0) in vec3 p;

void main()
{
    gl_Position = vec4(p.x, sin(10*p.x), 0, 1.0);
}