#version 330 core

in vec3 p;

out vec3 colour;

void main()
{
    gl_Position = vec4(p.x, p.y, p.z, 1.0);
	colour = vec3((p.x + 1) / 2, (p.y + 1) / 2, 0.5);
}