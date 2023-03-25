using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Tetris
{
    internal static class BaseElements
    {
        static float gap = 1.2f;

        public static void Cube(float x, float y, float z)
        {
            float w = 1.0f;
            float _gap = gap + w;
            float _x = x * _gap, _y = y * _gap, _z = z * _gap;

            // I start to draw my 3D cube
            Gl.glBegin(Gl.GL_POLYGON);
            // I'm setting a new color for each corner, this creates a rainbow effect
            Gl.glColor3f(0.0f, 0.475f, 0.42f);             // Set color to blue
            Gl.glVertex3f(_x + w, _y + w, _z + w);
            Gl.glColor3f(0.0f, 0.475f, 0.42f);             // Set color to red
            Gl.glVertex3f(_x + w, _y - w, _z + w);
            Gl.glColor3f(0.0f, 0.475f, 0.42f);             // Set color to green
            Gl.glVertex3f(_x - w, _y - w, _z + w);
            Gl.glColor3f(0.0f, 0.475f, 0.42f);     // Set color to something 
            Gl.glVertex3f(_x - w, _y + w, _z + w);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 0.475f, 0.42f);         // Set a new color
            Gl.glVertex3f(_x + w, _y + w, _z - w);
            Gl.glVertex3f(_x + w, _y - w, _z - w);
            Gl.glVertex3f(_x - w, _y - w, _z - w);
            Gl.glVertex3f(_x - w, _y + w, _z - w);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 0.475f, 0.42f);         // Set a new color (green)
            Gl.glVertex3f(_x + w, _y + w, _z + w);
            Gl.glVertex3f(_x + w, _y + w, _z - w);
            Gl.glVertex3f(_x + w, _y - w, _z - w);
            Gl.glVertex3f(_x + w, _y - w, _z + w);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 0.475f, 0.42f);
            Gl.glVertex3f(_x - w, _y + w, _z + w);
            Gl.glVertex3f(_x - w, _y - w, _z + w);
            Gl.glVertex3f(_x - w, _y - w, _z - w);
            Gl.glVertex3f(_x - w, _y + w, _z - w);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 0.475f, 0.42f);
            Gl.glVertex3f(_x + w, _y + w, _z + w);
            Gl.glVertex3f(_x + w, _y + w, _z - w);
            Gl.glVertex3f(_x - w, _y + w, _z - w);
            Gl.glVertex3f(_x - w, _y + w, _z + w);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 0.475f, 0.42f);
            Gl.glVertex3f(_x + w, _y - w, _z + w);
            Gl.glVertex3f(_x + w, _y - w, _z - w);
            Gl.glVertex3f(_x - w, _y - w, _z - w);
            Gl.glVertex3f(_x - w, _y - w, _z + w);
            Gl.glEnd();
        }

        public static void Rectangular(float x, float y, float z, float width = 3.0f, float height = 3.0f, float length = 3.0f)
        {
            float _x = x, _y = y, _z = z;

            // I start to draw my 3D cube
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);             // Set color to blue
            Gl.glVertex3f(_x + width, _y + height, _z + length);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);             // Set color to red
            Gl.glVertex3f(_x + width, _y - height, _z + length);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);             // Set color to green
            Gl.glVertex3f(_x - width, _y - height, _z + length);
            Gl.glColor3f(1.0f, 0.0f, 1.0f);     // Set color to something 
            Gl.glVertex3f(_x - width, _y + height, _z + length);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.50f, 0.50f, 1.0f);         // Set a new color
            Gl.glVertex3f(_x + width, _y + height, _z - length);
            Gl.glVertex3f(_x + width, _y - height, _z - length);
            Gl.glVertex3f(_x - width, _y - height, _z - length);
            Gl.glVertex3f(_x - width, _y + height, _z - length);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);         // Set a new color (green)
            Gl.glVertex3f(_x + width, _y + height, _z + length);
            Gl.glVertex3f(_x + width, _y + height, _z - length);
            Gl.glVertex3f(_x + width, _y - height, _z - length);
            Gl.glVertex3f(_x + width, _y - height, _z + length);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.50f, 1.0f, 0.50f);
            Gl.glVertex3f(_x - width, _y + height, _z + length);
            Gl.glVertex3f(_x - width, _y - height, _z + length);
            Gl.glVertex3f(_x - width, _y - height, _z - length);
            Gl.glVertex3f(_x - width, _y + height, _z - length);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(_x + width, _y + height, _z + length);
            Gl.glVertex3f(_x + width, _y + height, _z - length);
            Gl.glVertex3f(_x - width, _y + height, _z - length);
            Gl.glVertex3f(_x - width, _y + height, _z + length);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1.0f, 0.50f, 0.50f);
            Gl.glVertex3f(_x + width, _y - height, _z + length);
            Gl.glVertex3f(_x + width, _y - height, _z - length);
            Gl.glVertex3f(_x - width, _y - height, _z - length);
            Gl.glVertex3f(_x - width, _y - height, _z + length);
            Gl.glEnd();
        }
    }
}
