#version 330 core

in vec3 position;
out vec3 colour;

uniform mat4 transformationMatrix;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;

void main()
{
    float x = position.x, y = position.y, z = position.z;
    gl_Position = projectionMatrix * viewMatrix * transformationMatrix * vec4(x, y, 0.5*sin(50*sqrt(x*x+y*y)), 1.0);
	colour = vec3((x + 1) / 2, (y + 1) / 2, 0.5);
}
