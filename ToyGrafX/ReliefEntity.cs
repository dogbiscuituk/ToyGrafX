namespace ToyGrafX
{
    using OpenTK;

    public class ReliefEntity : Entity
    {
        public ReliefEntity(Model model, Vector3 position, float rotX, float rotY, float rotZ, float scale)
            : base(model, position, rotX, rotY, rotZ, scale)
        {
        }

        public string Formula;

        protected override string FragmentShaderText => $@"

#version 330 core
out vec4 FragColor;

void main()
{{
    FragColor = vec4(0.0f, 0.0f, 0.0f, 1.0f);
}}

";

        protected override string VertexShaderText => $@"

#version 330 core
layout (location = 0) in vec3 p;

void main()
{{
    float x = p.x, y = p.y;
    gl_Position = vec4(x, y, {Formula}, 1.0f);
}}

";
    }
}
