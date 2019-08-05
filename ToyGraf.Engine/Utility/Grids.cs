namespace ToyGraf.Engine.Utility
{
    public static class Grids
    {
        #region GetVertexCoords#D

        /// <summary>
        /// Get the coordinates of all points equally spaced along the X axis, where -1 <= X <= +1.
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <returns>/// An array of 3(cX+1) floats, being the XYZ coordinates of the points on the X axis (Y=Z=0).</returns>
        public static float[] GetVertexCoords(uint cX)
        {
            var result = new float[3 * (cX + 1)];
            var p = 0;
            for (var i = 0; i <= cX; i++)
            {
                var X = 2f * i / cX - 1;
                result[p++] = X;
                result[p++] = 0;
                result[p++] = 0;
            }
            return result;
        }

        /// <summary>
        /// Get the coordinates of all points on a regular 2D XY grid, where -1 <= X,Y <= +1.
        /// Points are returned ordered by X value, then by Y value.
        /// In other words, X varies more slowly, and Y more quickly.
        /// The diagram below shows the return order of the nine vertices in a 3x3 grid (cX=cY=2).
        /// 
        ///          Y
        ///          |
        ///        3 6 9
        ///     ---2 5 8---X
        ///        1 4 7
        ///          |
        ///
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <param name="cY">The number of steps along the Y axis.</param>
        /// <returns>
        /// An array of 3(cX+1)(cY+1) floats, being the XYZ coordinates of the points on the grid (Z=0).
        /// </returns>
        public static float[] GetVertexCoords(uint cX, uint cY)
        {
            var result = new float[3 * (cX + 1) * (cY + 1)];
            var p = 0;
            for (var i = 0; i <= cX; i++)
            {
                var X = 2f * i / cX - 1;
                for (int j = 0; j <= cY; j++)
                {
                    var Y = 2f * j / cY - 1;
                    result[p++] = X;
                    result[p++] = Y;
                    result[p++] = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Get the coordinates of all points in a regular 3D XYZ lattice, where -1 <= X,Y,Z <= +1.
        /// Points are returned ordered by X value, then by Y value, and finally by Z value.
        /// In other words, X varies most slowly, and Z most quickly.
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <param name="cY">The number of steps along the Y axis.</param>
        /// <param name="cZ">The number of steps along the Z axis.</param>
        /// <returns>
        /// 3(cX+1)(cY+1)(cZ+1) floats, being the XYZ coordinates of the points in the lattice.
        /// </returns>
        public static float[] GetVertexCoords(uint cX, uint cY, uint cZ)
        {
            var result = new float[3 * (cX + 1) * (cY + 1) * (cZ + 1)];
            var p = 0;
            for (var i = 0; i <= cX; i++)
            {
                var X = 2f * i / cX - 1;
                for (int j = 0; j <= cY; j++)
                {
                    var Y = 2f * j / cY - 1;
                    for (int k = 0; k <= cZ; k++)
                    {
                        var Z = 2f * k / cZ - 1;
                        result[p++] = X;
                        result[p++] = Y;
                        result[p++] = Z;
                    }
                }
            }
            return result;
        }

        #endregion

        #region Get[PrimitiveType]Indices

        /// <summary>
        /// Get the order of vertices required to draw triangles covering the grid.
        /// This method uses the vertex return order implemented by GetVertexCoords.
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <param name="cY">The number of steps along the Y axis.</param>
        /// A total of 6*cX*cY uints, ranging from 0 to 3(cX+1)(cY+1)-1 inclusive. These are the
        /// required vertex indices. Note that these must be multiplied by 3 to index the float data
        /// returned by GetVertexCoords, as every such vertex is postprocessed to add a Z coordinate
        /// of zero, and so eventually comprises 3 floats in total.
        public static uint[] GetTriangleIndices(uint cX, uint cY)
        {
            var result = new uint[6 * cX * cY];
            uint p = 0, q = 0;
            for (uint i = 0; i < cX; i++)
            {
                for (uint j = 0; j < cY; j++)
                {
                    result[p++] = q;
                    result[p++] = q++ + cY + 1;
                    result[p++] = q;
                    result[p++] = q;
                    result[p++] = q + cY;
                    result[p++] = q + cY + 1;
                }
                q++;
            }
            return result;
        }

        /// <summary>
        /// Get the order of vertices required to draw a single continuous triangle strip covering
        /// the grid. This method uses the vertex return order implemented by GetVertexCoords, and
        /// the output is a sequence of alternately ascending and descending strips. For the 6x3
        /// example below (cX=5, cY=2), the 26-element returned sequence is:
        /// 
        ///     00 - 03-01-04-02-05 - 08-04-07-03-06
        ///        - 09-07-10-08-11 - 14-10-03-09-12
        ///        - 15-13-16-14-17
        ///        
        /// To see this, play Snakes & Ladders. Start in the bottom left corner 00, and climb first
        /// up the ladder 03-01-04-02-05, then down the snake 08-04-07-03-06. Now climb back up the
        /// ladder 09-07-10-08-11, and down 14-10-13-09-12. Lastly climb 15-13-16-14-17 and declare
        /// victory. The result describes a single triangle strip, covering the entire grid, though
        /// with degenerate or "null" triangles at 02-05-08, 03-06-09, 08-11-14, and 09-12-15. This
        /// pattern has cX-2 such triangles, so a 1001x1001 grid (cX=cY=1000) will have more than 2
        /// million triangles, less than a thousand of which are degenerate. Hence, any performance
        /// improvement from further grid optimization will be limited to less than 0.05%.
        /// 
        ///     02--05--08--11--14--17
        ///       \    /  \    /  \
        ///        \  /    \  /    \
        ///     01--04--07--10--13--16
        ///       \    /  \    /  \
        ///        \  /    \  /    \
        ///     00--03--06--09--12--15
        /// 
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <param name="cY">The number of steps along the Y axis.</param>
        /// <returns>
        /// A total of cX(2cY+1)+1 uints, ranging from 0 to 3(cX+1)(cY+1)-1 inclusive. These are the
        /// required vertex indices. Note that these must be multiplied by 3 to index the float data
        /// returned by GetVertexCoords, as every such vertex is postprocessed to add a Z coordinate
        /// of zero, and so eventually comprises 3 floats in total.
        /// </returns>
        public static uint[] GetTriangleStripIndices(uint cX, uint cY)
        {
            var result = new uint[cX * (2 * cY + 1) + 1];
            uint p = 0;
            result[p++] = 0;
            uint q = 0;
            for (uint i = 0; i < cX; i++)
            {
                for (uint j = 0; j < cY; j++)
                {
                    result[p++] = q + cY + 1;
                    result[p++] = (i & 1) == 0 ? ++q : --q;
                }
                result[p++] = q += cY + 1;
            }
            return result;
        }

        #endregion
    }
}
