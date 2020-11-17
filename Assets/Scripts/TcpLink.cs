using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class TcpLink : MonoBehaviour
{
    #region private members 	
    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    private string serverMessage;

    #endregion

    private static string clientMessage;
    // Start is called before the first frame update
    void Start()
    {
        serverMessage = "No Message Received";
        clientMessage = "Test Client Connection";
        ConnectToTcpServer();
    }

    // Update is called once per frame
    float period = 0.0f;

    void Update()
    {
        if (period > .1f)
        {
            SendMessage();
            //Debug.Log(clientMessage);
            period = period-.1f;
        }
        period += UnityEngine.Time.deltaTime;
    }
    
    public string serverOut() {
        return serverMessage;
    }
    public void sendMessageToServer(string input) {
        clientMessage = input;
        //Debug.Log(clientMessage);
    }
    private void ConnectToTcpServer()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }
    }
    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient("www.dendendelen.com", 2323);
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                // Get a stream object for reading 				
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    // Read incomming stream into byte arrary. 					
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        // Convert byte array to string message. 						
                        serverMessage = Encoding.ASCII.GetString(incommingData);
                        Debug.Log("server message received as: " + serverMessage);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
        catch (System.InvalidOperationException iException) {
            Debug.Log("Server is gone");
        }
    }
    private void SendMessage()
    {
        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {

                // Convert string message to byte array.
                Debug.Log(clientMessage);
                Debug.Log("Sending it across...");
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                //Debug.Log("Client sent his message - should be received by server");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }
    public void CloseSocket()
    {
        socketConnection.GetStream().Close();
        socketConnection.Close();

    }
}
