using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli.Dat
{
    public class Map_Default
    {
        public static int amountOfDots = 6;
        public static double[] hexagon_Tile = { 0 };
        public static double[] hexagon_corner_Colour = { 0 };

        public Map_Default() 
        {
            hexagon_Tile = new double[21];

            hexagon_Tile[0] = (double)0;
            hexagon_Tile[1] = (double)0;
            hexagon_Tile[2] = (double)0;

            hexagon_Tile[3] = (double)1;
            hexagon_Tile[4] = (double)0;
            hexagon_Tile[5] = (double)0;

            hexagon_Tile[6] = (double)0.5;
            hexagon_Tile[7] = (double)(System.Math.Cbrt(3) / 2);
            hexagon_Tile[8] = (double)0;

            hexagon_Tile[9] = (double)(-0.5);
            hexagon_Tile[10] = (double)(System.Math.Cbrt(3) / 2);
            hexagon_Tile[11] = (double)0;

            hexagon_Tile[12] = (double)(-1);
            hexagon_Tile[13] = (double)0;
            hexagon_Tile[14] = (double)0;

            hexagon_Tile[15] = (double)(-0.5);
            hexagon_Tile[16] = (double)(-System.Math.Cbrt(3) / 2);
            hexagon_Tile[17] = (double)0;

            hexagon_Tile[18] = (double)0.5;
            hexagon_Tile[19] = (double)(-System.Math.Cbrt(3) / 2);
            hexagon_Tile[20] = (double)0;

            hexagon_corner_Colour = new double[21];

            hexagon_corner_Colour[0] = (double)0.0f;
            hexagon_corner_Colour[1] = (double)0.0f;
            hexagon_corner_Colour[2] = (double)0.0f;

            hexagon_corner_Colour[3] = (double)1.0f;
            hexagon_corner_Colour[4] = (double)0.0f;
            hexagon_corner_Colour[5] = (double)0.0f;

            hexagon_corner_Colour[6] = (double)1.0f;
            hexagon_corner_Colour[7] = (double)1.0f;
            hexagon_corner_Colour[8] = (double)1.0f;

            hexagon_corner_Colour[9] = (double)0.0f;
            hexagon_corner_Colour[10] = (double)1.0f;
            hexagon_corner_Colour[11] = (double)0.0f;

            hexagon_corner_Colour[12] = (double)1.0f;
            hexagon_corner_Colour[13] = (double)1.0f;
            hexagon_corner_Colour[14] = (double)1.0f;

            hexagon_corner_Colour[15] = (double)0.0f;
            hexagon_corner_Colour[16] = (double)0.0f;
            hexagon_corner_Colour[17] = (double)1.0f;

            hexagon_corner_Colour[18] = (double)1.0f;
            hexagon_corner_Colour[19] = (double)1.0f;
            hexagon_corner_Colour[20] = (double)1.0f;

            System.Console.WriteLine("FLORENCE: Map_Default");
        }

        public void Draw_Square(FLORENCE.Frame.Cli.Data data)
        {
            GL.DrawElements(
                PrimitiveType.Triangles,
                data.GetThirdOutputBuffer().Get_Indices().Length,
                DrawElementsType.UnsignedInt,
                0
            );
        }

        public void Draw_Triangle()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
        }

        public void Draw_Hexagon()
        {

            float[] vertices = {
                            0, 0, 0,  0, 0, 0,
                            0, 0, 0,  0, 0, 0,
                            0, 0, 0,  0, 0, 0,
                        };
            for (int i = 0; i < 6; i++)
            {
                vertices[0] = (float)hexagon_Tile[0];
                vertices[1] = (float)hexagon_Tile[1];
                vertices[2] = (float)hexagon_Tile[2];
                vertices[3] = (float)hexagon_corner_Colour[0];
                vertices[4] = (float)hexagon_corner_Colour[1];
                vertices[5] = (float)hexagon_corner_Colour[2];

                vertices[6] = (float)hexagon_Tile[(i * 3) + 3];
                vertices[7] = (float)hexagon_Tile[(i * 3) + 4];
                vertices[8] = (float)hexagon_Tile[(i * 3) + 5];
                vertices[9] = (float)hexagon_corner_Colour[(i * 3) + 3];
                vertices[10] = (float)hexagon_corner_Colour[(i * 3) + 4];
                vertices[11] = (float)hexagon_corner_Colour[(i * 3) + 5];

                if (i != 5)
                {
                    vertices[12] = (float)hexagon_Tile[(i * 3) + 6];
                    vertices[13] = (float)hexagon_Tile[(i * 3) + 7];
                    vertices[14] = (float)hexagon_Tile[(i * 3) + 8];
                    vertices[15] = (float)hexagon_corner_Colour[(i * 3) + 6];
                    vertices[16] = (float)hexagon_corner_Colour[(i * 3) + 7];
                    vertices[17] = (float)hexagon_corner_Colour[(i * 3) + 8];
                }
                else
                {
                    vertices[12] = (float)hexagon_Tile[3];
                    vertices[13] = (float)hexagon_Tile[4];
                    vertices[14] = (float)hexagon_Tile[5];
                    vertices[15] = (float)hexagon_corner_Colour[3];
                    vertices[16] = (float)hexagon_corner_Colour[4];
                    vertices[17] = (float)hexagon_corner_Colour[5];
                }
                GL.BufferData(
                    BufferTarget.ArrayBuffer,
                    vertices.Length * sizeof(float),
                    vertices,
                    BufferUsageHint.StreamDraw
                );

                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            }
        }

        public double[] Get_Hexagon()
        {
            return hexagon_Tile;
        }
    }
}