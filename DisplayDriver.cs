using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Cosmos.HAL;
using Sys = Cosmos.System;
namespace Hardware
{
    public class DisplayDriver
    {

        protected VGAScreen screen;
        private int width, height;
        public String s;

        public DisplayDriver()
        {
            screen = new VGAScreen();
            s = null;
        }

        public void init()
        {
            screen.SetGraphicsMode(VGAScreen.ScreenSize.Size320x200, VGAScreen.ColorDepth.BitDepth8);
            screen.Clear(0);
            width = screen.PixelWidth;
            height = screen.PixelHeight;
            screen.SetPaletteEntry(0, 3, 63, 3);
            //drawFilledRectangle(0, 180, 320, 20, 42);
            //drawRectangle(0, 180, 320, 20, 40);
            //drawFilledRectangle(0, 180, 80, 20, 43);
            //drawRectangle(0, 180, 80, 20, 40);
            drawHappyFace(160, 100, 18, 20);

            //int dclr = 41;
            ////Q
            //drawCircle(10, 190, 6, dclr);
            //setPixel(13, 191, dclr);
            //setPixel(14, 192, dclr);
            //setPixel(15, 193, dclr);
            //setPixel(16, 194, dclr);
            //setPixel(17, 195, dclr);

            ////u
            //drawVLine(27, 185, 8, dclr);
            //drawVLine(33, 185, 10, dclr);
            //setPixel(28, 194, dclr);
            //setPixel(29, 195, dclr);
            //setPixel(30, 195, dclr);
            //setPixel(31, 194, dclr);
            //setPixel(32, 193, dclr);

            ////i
            //drawVLine(50, 188, 7, dclr);
            //setPixel(50, 185, dclr);


            ////t
            //drawVLine(68, 185, 10, dclr);
            //drawHLine(65, 188, 8, dclr);
            //setPixel(69, 195, dclr);
            //setPixel(70, 195, dclr);
            //setPixel(71, 194, dclr);
        }


        public virtual void setPixel(int x, int y, int c)
        {
            if (screen.GetPixel320x200x8((uint)x, (uint)y) != (uint)c)
                setPixelRaw(x, y, c);
        }

        //change byte to uint
        public virtual uint getPixel(int x, int y)
        {
            return (uint)screen.GetPixel320x200x8((uint)x, (uint)y);
        }

        public virtual void clear()
        {
            clear(0);
        }

        public virtual void clear(int c)
        {
            screen.Clear(c);
        }

        public virtual void step() { }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public void setPixelRaw(int x, int y, int c)
        {

            screen.SetPixel320x200x8((uint)x, (uint)y, (uint)c);

        }

        public void drawFilledRectangle(uint x0, uint y0, int Width, int Height, int color)
        {
            for (uint i = 0; i < Width; i++)
            {
                for (uint h = 0; h < Height; h++)
                {
                    setPixel((int)(x0 + i), (int)(y0 + h), color);
                }
            }
        }

        public void drawRectangle(uint x0, uint y0, int Width, int Height, int color)
        {
            for (uint i = 0; i < Width; i++)
            {
                setPixel((int)(x0 + i), (int)(y0), color);
                setPixel((int)(x0 + i), (int)(y0 + 1), color);
            }
            for (uint i = 0; i < Width; i++)
            {
                setPixel((int)(x0 + i), (int)(y0 + Height), color);
                setPixel((int)(x0 + i), (int)(y0 + Height - 1), color);
            }
            for (uint i = 0; i < Height; i++)
            {
                setPixel((int)(x0), (int)(y0 + i), color);
                setPixel((int)(x0 + 1), (int)(y0 + i), color);
            }
            for (uint i = 0; i < Height; i++)
            {
                setPixel((int)(x0 + Width), (int)(y0 + i), color);
                setPixel((int)(x0 + Width - 1), (int)(y0 + i), color);
            }
        }

        public void drawHappyFace(uint x0, uint y0, int radius, int color)
        {
            for (int y = -radius; y <= radius; y++)
                for (int x = -radius; x <= radius; x++)
                    if (x * x + y * y <= radius * radius)
                        setPixel((int)x0 + x, (int)y0 + y, color);

            setPixel((int)x0 - 3, (int)y0 - 2, 255);
            setPixel((int)x0 - 4, (int)y0 - 2, 255);
            setPixel((int)x0 - 3, (int)y0 - 3, 255);
            setPixel((int)x0 - 4, (int)y0 - 3, 255);
            setPixel((int)x0 - 2, (int)y0 - 4, 255);
            setPixel((int)x0 - 3, (int)y0 - 4, 255);
            setPixel((int)x0 - 4, (int)y0 - 4, 255);
            setPixel((int)x0 - 2, (int)y0 - 5, 255);
            setPixel((int)x0 - 3, (int)y0 - 5, 255);
            setPixel((int)x0 - 4, (int)y0 - 5, 255);
            setPixel((int)x0 - 3, (int)y0 - 6, 255);
            setPixel((int)x0 - 4, (int)y0 - 6, 255);
            setPixel((int)x0 - 3, (int)y0 - 7, 255);
            setPixel((int)x0 - 4, (int)y0 - 7, 255);

            setPixel((int)x0 + 3, (int)y0 - 2, 255);
            setPixel((int)x0 + 4, (int)y0 - 2, 255);
            setPixel((int)x0 + 3, (int)y0 - 3, 255);
            setPixel((int)x0 + 4, (int)y0 - 3, 255);
            setPixel((int)x0 + 2, (int)y0 - 4, 255);
            setPixel((int)x0 + 3, (int)y0 - 4, 255);
            setPixel((int)x0 + 4, (int)y0 - 4, 255);
            setPixel((int)x0 + 2, (int)y0 - 5, 255);
            setPixel((int)x0 + 3, (int)y0 - 5, 255);
            setPixel((int)x0 + 4, (int)y0 - 5, 255);
            setPixel((int)x0 + 3, (int)y0 - 6, 255);
            setPixel((int)x0 + 4, (int)y0 - 6, 255);
            setPixel((int)x0 + 3, (int)y0 - 7, 255);
            setPixel((int)x0 + 4, (int)y0 - 7, 255);

            setPixel((int)x0 + 0, (int)y0 + 10, 255);
            setPixel((int)x0 + 1, (int)y0 + 10, 255);
            setPixel((int)x0 - 1, (int)y0 + 10, 255);
            setPixel((int)x0 + 2, (int)y0 + 10, 255);
            setPixel((int)x0 - 2, (int)y0 + 10, 255);
            setPixel((int)x0 + 3, (int)y0 + 9, 255);
            setPixel((int)x0 - 3, (int)y0 + 9, 255);
            setPixel((int)x0 + 4, (int)y0 + 9, 255);
            setPixel((int)x0 - 4, (int)y0 + 9, 255);
            setPixel((int)x0 + 5, (int)y0 + 8, 255);
            setPixel((int)x0 - 5, (int)y0 + 8, 255);
            setPixel((int)x0 + 6, (int)y0 + 7, 255);
            setPixel((int)x0 - 6, (int)y0 + 7, 255);

        }

        public void drawVLine(uint x0, uint y0, int Height, int color)
        {
            for (uint i = 0; i < Height; i++)
            {
                setPixel((int)(x0), (int)(y0 + i), color);
            }
        }

        public void drawHLine(uint x0, uint y0, int Width, int color)
        {
            for (uint i = 0; i < Width; i++)
            {
                setPixel((int)(x0 + i), (int)(y0), color);
            }
        }

        public void drawCircle(uint x0, uint y0, int radius, int color)
        {
            for (int y = -radius; y <= radius; y++)
                for (int x = -radius; x <= radius; x++)
                    if (x * x + y * y <= radius * radius && x * x + y * y > (radius - 1) * (radius - 1))
                        setPixel((int)x0 + x, (int)y0 + y, color);
        }

        public void drawButton(Button b)
        {
            drawFilledRectangle(b.X0, b.Y0, (int)(b.X1 - b.X0), (int)(b.Y1 - b.Y0), b.background_clr);
            drawRectangle(b.X0, b.Y0, (int)(b.X1-b.X0), (int)(b.Y1-b.Y0), b.edge_clr);
            s = b.label;
            drawLabel(b.X0, b.Y0);
        }

        public void drawLabel(uint x0, uint y0)
        {
            uint x = x0 + 2;
            uint y = y0 + 2;
            char[] arry = s.ToCharArray();
            for(int i=0; i<arry.Length; i++)
            {
                drawCharacters(x + 2, y + 2, arry[i]);
                x = x + 20;
            }
        }

        public void setLargePixel(int x0, int y0, int color)
        {
            setPixel(x0, y0, color);
            setPixel(x0, y0 + 1, color);
            setPixel(x0, y0 + 2, color);
            setPixel(x0, y0 + 3, color);
            setPixel(x0+1, y0, color);
            setPixel(x0+1, y0+1, color);
            setPixel(x0+1, y0+2, color);
            setPixel(x0 + 1, y0 + 3, color);
            setPixel(x0 + 2, y0 + 0, color);
            setPixel(x0 + 2, y0 + 1, color);
            setPixel(x0 + 2, y0 + 2, color);
            setPixel(x0 + 2, y0 + 3, color);
            setPixel(x0 + 3, y0 + 0, color);
            setPixel(x0 + 3, y0 + 1, color);
            setPixel(x0 + 3, y0 + 2, color);
            setPixel(x0 + 3, y0 + 3, color);
        }

        public void drawCharacters(uint x0, uint y0, Char c) 
        {
            int clr = 40;
            switch (c) {
                case 'C':
                    setLargePixel((int)x0 + 0, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 12, clr);
                    break; 

                case 'L':
                    setLargePixel((int)x0 + 0, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 16, clr);
                    break;
                case 'E':
                    setLargePixel((int)x0 + 0, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 8, clr);
                    break;
                case 'A':
                    setLargePixel((int)x0 + 0, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 16, clr);
                    break;
                case 'R':
                    setLargePixel((int)x0 + 0, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 16, clr);
                    break;
                case 'Q':
                    setLargePixel((int)x0 + 0, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 16, clr);
                    break;
                case 'U':
                    setLargePixel((int)x0 + 0, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 0, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 16, clr); 
                    break;
                case 'I':
                    setLargePixel((int)x0 + 2, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 6, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 10, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 2, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 6, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 10, (int)y0 + 16, clr);
                    setLargePixel((int)x0 + 6, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 6, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 6, (int)y0 + 12, clr);                    
                    break;
                case 'T':
                    setLargePixel((int)x0 + 0, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 4, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 8, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 12, (int)y0 + 0, clr);
                    setLargePixel((int)x0 + 6, (int)y0 + 4, clr);
                    setLargePixel((int)x0 + 6, (int)y0 + 8, clr);
                    setLargePixel((int)x0 + 6, (int)y0 + 12, clr);
                    setLargePixel((int)x0 + 6, (int)y0 + 16, clr);
                    break;
                default: break;
              
            }
        }
    }
}
