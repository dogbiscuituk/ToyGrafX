#version 330 core

in vec3 p;
out vec3 colour;

uniform mat4 transformationMatrix;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;

void main()
{
    gl_Position = projectionMatrix * viewMatrix * transformationMatrix * vec4(p.x, p.y, 0.5*sin(50*sqrt(p.x*p.x+p.y*p.y)), 1.0);
	colour = vec3((p.x + 1) / 2, (p.y + 1) / 2, 0.5);
}
