using Cosmos.HAL;
using Sys = Cosmos.System;

namespace Hardware
{
    public class Mouse
    {
        private Cosmos.HAL.Mouse mouse;
        private byte[] c = new byte[8];

        public int X
        {
            get
            {
                return (int)mouse.X;
            }
        }
        public int Y
        {
            get
            {
                return (int)mouse.Y;
            }
        }
        public int LastDrawX;
        public int LastDrawY;

        public Mouse()
        {
            mouse = new Cosmos.HAL.Mouse();
            mouse.Initialize(320, 200);
        }

        public bool click()
        {
            return mouse.Buttons == Cosmos.HAL.Mouse.MouseState.Left;
        }

        public void drawMouse(DisplayDriver display)
        {
            if (X != LastDrawX || Y != LastDrawY)
            {

                display.setPixel(LastDrawX, LastDrawY, (int)c[0]);
                display.setPixel(LastDrawX + 1, LastDrawY, (int)c[1]);
                display.setPixel(LastDrawX + 2, LastDrawY, (int)c[2]);
                display.setPixel(LastDrawX, LastDrawY + 1, (int)c[3]);
                display.setPixel(LastDrawX, LastDrawY + 2, (int)c[4]);
                display.setPixel(LastDrawX + 1, LastDrawY + 1, (int)c[5]);
                display.setPixel(LastDrawX + 2, LastDrawY + 2, (int)c[6]);
                display.setPixel(LastDrawX + 3, LastDrawY + 3, (int)c[7]);

                c[0] = (byte) display.getPixel(X, Y);
                c[1] = (byte)display.getPixel(X + 1, Y);
                c[2] = (byte)display.getPixel(X + 2, Y);
                c[3] = (byte)display.getPixel(X, Y + 1);
                c[4] = (byte)display.getPixel(X, Y + 2);
                c[5] = (byte)display.getPixel(X + 1, Y + 1);
                c[6] = (byte)display.getPixel(X + 2, Y + 2);
                c[7] = (byte)display.getPixel(X + 3, Y + 3);

                display.setPixel(X, Y, 40);
                display.setPixel(X + 1, Y, 40);
                display.setPixel(X + 2, Y, 40);
                display.setPixel(X, Y + 1, 40);
                display.setPixel(X, Y + 2, 40);
                display.setPixel(mouse.X + 1, mouse.Y + 1, 40);
                display.setPixel(mouse.X + 2, mouse.Y + 2, 40);
                display.setPixel(mouse.X + 3, mouse.Y + 3, 40);

                LastDrawX = X;
                LastDrawY = Y;
            }
        }

        public void refreshPixel(DisplayDriver display)
        {
            c[0] = (byte)display.getPixel(X, Y);
            c[1] = (byte)display.getPixel(X + 1, Y);
            c[2] = (byte)display.getPixel(X + 2, Y);
            c[3] = (byte)display.getPixel(X, Y + 1);
            c[4] = (byte)display.getPixel(X, Y + 2);
            c[5] = (byte)display.getPixel(X + 1, Y + 1);
            c[6] = (byte)display.getPixel(X + 2, Y + 2);
            c[7] = (byte)display.getPixel(X + 3, Y + 3);

        }
    }
}
