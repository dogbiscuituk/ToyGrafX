namespace ToyGrafX
{
    using OpenTK.Graphics.OpenGL;
    using System.Collections.Generic;

    public class Loader
    {
        public Model LoadToVAO(float[] positions)
        {
            int vaoID = CreateVAO();
            StoreDataInAttributeList(0, positions);
            UnbindVAO();
            return new Model(vaoID, positions.Length / 3);
        }

        public void Cleanup()
        {
            foreach (var vaoID in VAOs)
                GL.DeleteVertexArray(vaoID);
            VAOs.Clear();
            foreach (var vboID in VBOs)
                GL.DeleteBuffer(vboID);
            VBOs.Clear();
        }

        private readonly List<int> VAOs = new List<int>();
        private readonly List<int> VBOs = new List<int>();

        private int CreateVAO()
        {
            GL.GenVertexArrays(1, out int vaoID);
            VAOs.Add(vaoID);
            GL.BindVertexArray(vaoID);
            return vaoID;
        }

        private void StoreDataInAttributeList(int attributeNumber, float[] data)
        {
            GL.GenBuffers(1, out int vboID);
            VBOs.Add(vboID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(attributeNumber, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        private void UnbindVAO()
        {
            GL.BindVertexArray(0);
        }
    }
}
