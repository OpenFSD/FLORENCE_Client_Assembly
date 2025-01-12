using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly.game_Instance
{
    public class Player
    {
        private Client_Assembly.game_Instance.gFX.Camera camera;

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
            camera = new Client_Assembly.game_Instance.gFX.Camera(Vector3.UnitZ * 3, 16 / (float)9);
        }
        public void Move_Backwards(float period)
        {
            //TODO Create praise, push_stack_InputActions
            Vector3 temp = camera.Position - (camera.Front * cameraSpeed * period); // Backwards
            Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).Set_PlayerPosition(
                temp
            );          
        }

        public void Move_Fowards(float period)
        {
            //TODO Create praise, push_stack_InputActions
            Vector3 temp = camera.Position + (camera.Front * cameraSpeed * period);// Forward
            Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).Set_PlayerPosition(
                temp
            );
        }

        public void Move_Left(float period)
        {
            //TODO Create praise, push_stack_InputActions
            Vector3 temp = camera.Position - (camera.Right * cameraSpeed * period);// Left
            Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).Set_PlayerPosition(
                temp
            );
        }

        public void Move_Right(float period)
        {
            //TODO Create praise, push_stack_InputActions
            Vector3 temp = camera.Position + (camera.Right * cameraSpeed * period);// Right
            Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).Set_PlayerPosition(
                temp
            );
        }

        public Client_Assembly.game_Instance.gFX.Camera GetCamera()
        {
            return camera;
        }

        public bool Get_isFirstMove()
        {
            return _firstMove;
        }

        public int GetInt_OfInputBuffer()
        {
            if (Framework.GetClient().GetData().GetState_Buffer_InputPraise_SideToWrite() == false)
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
            //TODO Create praise, push_stack_InputActions
            Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).Set_MousePos(pos);
            
            // Calculate the offset of the mouse position
            var deltaX = Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetMousePos().X - mousePos.X;
            var deltaY = Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetMousePos().Y - mousePos.Y;

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
