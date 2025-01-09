using FLORENCE.Frame.Cli.Dat.Out.Gfx;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli.Dat.In
{
    public class Player
    {
        private FLORENCE.Frame.Cli.Dat.Out.Gfx.Camera camera;

        private bool _firstMove = false;

        private bool isPlayerMoved = true;
        private Vector3 player_Position;
        //private Vector3 new_Player_Position;

        bool isMouseChanged = false;
        private Vector2 mousePos;
        //private Vector2 new_MousePos;

        const float cameraSpeed = 1.5f;
        const float sensitivity = 0.2f;

        public Player() 
        {
            _firstMove = true;
            camera = new Camera(Vector3.UnitZ * 3, 16 / (float)9);
        }
        public void Move_Backwards(FrameEventArgs e)
        {
            Vector3 temp = camera.Position - (camera.Front * cameraSpeed * (float)e.Time); // Backwards
            Framework.GetClient().GetData().GetBuffer_FrontInputDouble().GetPlayer().Set_PlayerPosition(
                temp
            );
        }

        public void Move_Fowards(FrameEventArgs e)
        {
            Vector3 temp = camera.Position + (camera.Front * cameraSpeed * (float)e.Time);// Forward
            Framework.GetClient().GetData().GetBuffer_FrontInputDouble().GetPlayer().Set_PlayerPosition(
                temp
            );
        }

        public void Move_Left(FrameEventArgs e)
        {
            Vector3 temp = camera.Position - (camera.Right * cameraSpeed * (float)e.Time);// Left
            Framework.GetClient().GetData().GetBuffer_FrontInputDouble().GetPlayer().Set_PlayerPosition(
                temp
            );
        }

        public void Move_Right(FrameEventArgs e)
        {
            Vector3 temp = camera.Position + (camera.Right * cameraSpeed * (float)e.Time);// Right
            Framework.GetClient().GetData().GetBuffer_FrontInputDouble().GetPlayer().Set_PlayerPosition(
                temp
            );
        }

        public FLORENCE.Frame.Cli.Dat.Out.Gfx.Camera GetCamera()
        {
            return camera;
        }

        public bool Get_isFirstMove()
        {
            return _firstMove;
        }

        public int GetInt_OfInputBuffer()
        {
            if (Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite() == false)
            {
                return (Int16)0;
            }
            else
            {
                return (Int32)1;
            }
        }
        public Vector2 GetMousePos()
        {
            return mousePos;
        }
   
        public Vector3 GetPlayerPosition()
        {
            return player_Position;
        }
     
        public void Set_isFirstMove(bool value)
        {
            _firstMove = value;
        }

        public void Set_MousePos(Vector2 pos)
        {
            Framework.GetClient().GetData().GetBuffer_FrontInputDouble().GetPlayer().Set_MousePos(pos);
            
            // Calculate the offset of the mouse position
            var deltaX = Framework.GetClient().GetData().GetBuffer_FrontInputDouble().GetPlayer().GetMousePos().X - mousePos.X;
            var deltaY = Framework.GetClient().GetData().GetBuffer_FrontInputDouble().GetPlayer().GetMousePos().Y - mousePos.Y;

            // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
            camera.Yaw += deltaX * sensitivity;
            camera.Pitch -= deltaY * sensitivity; // Reversed since y-coordinates range from bottom to top
        }

        public void Set_PlayerPosition(Vector3 position)
        {
            player_Position = position;
        }
    }
}
