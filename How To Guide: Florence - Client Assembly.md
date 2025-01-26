# How To Guide: Florence - Client Assembly.

## Flow.
Start: capture user periferal inputs and process each screen refresh.

FLORENCE_Client_Assembly\engine\gFX\Graphics.cs => ```protected override void OnUpdateFrame(FrameEventArgs e)```

- Stack_Client_InputAction.

FLORENCE_Client_Assembly\engine\IO_ListenRespond.cs => ```public void Thread_io_ListenRespond()```

Networking Client Send.

Networking Server Recieve.

- Stack_Server_InputAction.
  
- Stack_Server_InputPraise.
- Stack_Server_OutputPraise.
- Stack_Server_OutputRecieve.
- Stack_Client_OutputRecieve.
