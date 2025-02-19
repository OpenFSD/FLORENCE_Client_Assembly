using Client_Assembly.Praise_Files;
using Florence.WriteEnable;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly.game_Instance.gFX
{
    public class Graphics : GameWindow
    {
        private int ElementBufferObject;
        private int VertexArrayObject;
        private int VertexBufferObject;

        private Client_Assembly.game_Instance.gFX.Shader shader;

        private Client_Assembly.game_Instance.gFX.Texture texture0;
        private Client_Assembly.game_Instance.gFX.Texture texture1;

        bool done_once;

        // Get the mouse state
        MouseState mouse = null;

        private Matrix4 view;
        private Matrix4 projection;

        private static int nrAttributes;
        private static double time;

        public Graphics(OpenTK.Windowing.Desktop.GameWindowSettings gws, OpenTK.Windowing.Desktop.NativeWindowSettings nws) : base(
           gws,
           nws
        )
        {
            mouse = MouseState;
            done_once = true;
            System.Console.WriteLine("Client_Assembly: Graphics & GameWindow");
        }

        ~Graphics()
        {

        }
        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(
                BufferTarget.ArrayBuffer,
                VertexBufferObject
            );
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                Framework.GetClient().GetData().GetOutput_Instnace().GetBuffer_FrontOutputDouble().Get_Vertices().Length * sizeof(float),
                Framework.GetClient().GetData().GetOutput_Instnace().GetBuffer_FrontOutputDouble().Get_Vertices(),
                BufferUsageHint.StaticDraw
            );

            // draw square \/ \/ \/
            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(
                BufferTarget.ElementArrayBuffer,
                ElementBufferObject
            );
            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                Framework.GetClient().GetData().GetOutput_Instnace().GetBuffer_FrontOutputDouble().Get_Indices().Length * sizeof(uint),
                Framework.GetClient().GetData().GetOutput_Instnace().GetBuffer_FrontOutputDouble().Get_Indices(),
                BufferUsageHint.StaticDraw
            );
            // draw square /\ /\ /\

            shader = new Client_Assembly.game_Instance.gFX.Shader(
                "..\\..\\..\\engine\\gFX\\shader_vert.glsl",
                "..\\..\\..\\engine\\gFX\\shader_frag.glsl"
            );
            shader.Use();

            GL.VertexAttribPointer(
                0,
                3,
                VertexAttribPointerType.Float,
                false,
                5 * sizeof(float),
                0
            );
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(
                1,
                3,
                VertexAttribPointerType.Float,
                false,
                5 * sizeof(float),
                3 * sizeof(float)
            );
            GL.EnableVertexAttribArray(1);

            texture0 = Client_Assembly.game_Instance.gFX.Texture.LoadFromFile("..\\..\\..\\resources\\Textures\\container.jpg");
            texture0.Use((OpenTK.Graphics.OpenGL4.TextureUnit)TextureUnit.Texture0);

            texture1 = Client_Assembly.game_Instance.gFX.Texture.LoadFromFile("..\\..\\..\\resources\\Textures\\awesomeface.png");
            texture1.Use((OpenTK.Graphics.OpenGL4.TextureUnit)TextureUnit.Texture1);

            nrAttributes = 0;
            GL.GetInteger(GetPName.MaxVertexAttribs, out nrAttributes);
            Console.WriteLine("Maximum number of vertex attributes supported: " + nrAttributes);

            shader.SetInt("texture0", 0);
            shader.SetInt("texture1", 1);


            //CursorState = CursorState.Grabbed;
            /*
            view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
            projection = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45f), 
                Size.X / (float)Size.Y, 
                0.1f, 
                100.0f
            );
            */
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            time += 4.0 * e.Time;

            GL.Clear(
                ClearBufferMask.ColorBufferBit |
                ClearBufferMask.DepthBufferBit
            );
            GL.BindVertexArray(VertexArrayObject);

            texture0.Use((OpenTK.Graphics.OpenGL4.TextureUnit)TextureUnit.Texture0);
            texture1.Use((OpenTK.Graphics.OpenGL4.TextureUnit)TextureUnit.Texture1);
            shader.Use();

            var model = Matrix4.Identity * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(time));
            shader.SetMatrix4("model", model);
            shader.SetMatrix4("view", Client_Assembly.Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetCamera().GetViewMatrix());
            shader.SetMatrix4("projection", Client_Assembly.Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetCamera().GetProjectionMatrix());

            /*
            // change colour with time \/ \/ \/
                                        float greenValue = Get_New_greenValue();
                                        int vertexColorLocation = GL.GetUniformLocation(shader.Get_Handle(), "ourColor");
                                        GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);
            // change colour with time /\ /\ /\
            */
            Client_Assembly.Framework.GetClient().GetData().GetGame_Instance().GetMapDefault().Draw_Triangle();
            //Framework..Get_Client().Get_Data().Get_Map_Default().Draw_Square(Framework..Get_Client().Get_Data());

            SwapBuffers();
        }

        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            // Delete all the resources.
            GL.DeleteBuffer(VertexBufferObject);
            GL.DeleteVertexArray(VertexArrayObject);

            GL.DeleteProgram(shader.Get_Handle());

            shader.Dispose();

            base.OnUnload();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            if (done_once == true)
            {
                Client_Assembly.Framework.GetClient().GetExecute().GetExecute_Control().SetFlag_ThreadInitialised(0, false);
                System.Console.WriteLine("Thread Initalised => Thread_OnUpdateFrame()");//TestBench
                done_once = false;
                System.Console.WriteLine("Thread Starting => Thread_OnUpdateFrame()");//TestBench
            }

            float period = (float)e.Time;
            Framework.GetClient().GetData().GetInput_Instnace().SetBuffer_Input(Client_Assembly.Framework.GetClient().GetData().GetInput_Instnace().GetEmptyInput());

            if (!IsFocused) // Check to see if the window is focused
            {
                return;
            }
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                this.Close();
            }
            if (Framework.GetClient().GetData().GetData_Control().GetFlag_IsPraiseEvent(0) == false)
            {
                if (KeyboardState.IsKeyDown(Keys.Enter))//ping
                {
                    Framework.GetClient().GetData().GetData_Control().SetIsPraiseEvent(0, true);
                    // Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().SetPraiseEventId(0);
                    // Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().GetInputControl().SelectSetIntputSubset(0);
                    // Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().GetInputControl().LoadValuesInToInputSubset(0, period);
                    //Client_Assembly.Networking.CreateAndSendNewMessage(0);//todo
                }
            }
            if (Framework.GetClient().GetData().GetData_Control().GetFlag_IsPraiseEvent(1) == false)
            {
                Client_Assembly.game_Instance.Player in_Subset_praise1 = (Client_Assembly.game_Instance.Player)Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0);
                if ((in_Subset_praise1.GetMousePos().X != mouse.X)
                    || (in_Subset_praise1.GetMousePos().Y != mouse.Y)
                )//mouse move
                {
                    Framework.GetClient().GetData().GetData_Control().SetIsPraiseEvent(1, true);
                    // Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().SetPraiseEventId(1);
                    //Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().GetInputControl().SelectSetIntputSubset(1);
                    //Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().GetInputControl().LoadValuesInToInputSubset(1, period);
                    //Client_Assembly.Networking.CreateAndSendNewMessage(1);//todo
                }
            }
            if (Framework.GetClient().GetData().GetData_Control().GetFlag_IsPraiseEvent(2) == false)
            {
                if ((KeyboardState.IsKeyDown(Keys.W))
                    || (KeyboardState.IsKeyDown(Keys.S))
                    || (KeyboardState.IsKeyDown(Keys.A))
                    || (KeyboardState.IsKeyDown(Keys.D))
                )//player move
                {
                    Framework.GetClient().GetData().GetData_Control().SetIsPraiseEvent(2, true);
                    //Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().SetPraiseEventId(2);
                    //Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().GetInputControl().SelectSetIntputSubset(2);
                    //Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().GetInputControl().LoadValuesInToInputSubset(2, period);
                    //Client_Assembly.Networking.CreateAndSendNewMessage(2);//todo
                }
            }
        }
    
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetCamera().Fov -= e.OffsetY;
        }
        /*
public static float Get_New_greenValue()
{
periodOfRefresh += 0.0166666666666667;//period per frame - settings gws.UpdateFrequency = 60
if (periodOfRefresh == 2000) periodOfRefresh = 0;
return (float)Math.Sin(periodOfRefresh) / (2.0f + 0.5f);
}
*/
        public MouseState Get_MouseState()
        {
            return mouse;
        }

        public Vector2 GetNewMousePosition()
        {
            return new Vector2(mouse.Position.X, mouse.Position.Y);
        }
    }
}
