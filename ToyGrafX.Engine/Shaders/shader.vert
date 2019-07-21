#version 330 core

layout (location = 0) in vec3 position;
layout (location = 1) in float time;
out vec3 colour;

uniform mat4 transformationMatrix;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;

void main()
{
    float x = position.x, y = position.y, z = position.z;
	z = sqrt(x*x+y*y);
	z = cos(20*z+10*time)*exp(-3*z);
    gl_Position = projectionMatrix * viewMatrix * transformationMatrix * vec4(x, y, z, 1.0);
	colour = vec3((x + 1) / 2, (y + 1) / 2, 0.5);
}
