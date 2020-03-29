using System;
using System.Collections;
using System.Net.Sockets;

public class Client
{
    ////linefeed character
    //const int LF = 10;

    ////client list
    //public static Hashtable AllClients = new Hashtable();

    ////information about client
    //private TcpClient _client;
    //private string _clientIP;
    //private string _clientNick;

    ////used to store partial request
    //private string partialStr;

    ////sending and receiving data
    //private byte[] data;

    //public Client(TcpClient client)
    //{
    //    _client = client;
    //    _clientIP = client.Client.RemoteEndPoint.ToString();

    //    AllClients.Add(_clientIP, this);

    //    //start reading data from the client in a seperate thread
    //    data = new byte[_client.ReceiveBufferSize];
    //    _client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(_client.ReceiveBufferSize), ReceiveMessage, null);
    //}

    //public void SendMessage(string message)
    //{
    //    try
    //    {
    //        //send the text
    //        NetworkStream ns;
    //        lock (_client.GetStream())
    //        {
    //            ns = _client.GetStream();
    //            byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
    //            ns.Write(bytesToSend, 0, bytesToSend.Length);
    //            ns.Flush();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex.ToString());

    //    }
    //}
    //public void Broadcast(string message, string[] users)
    //{
    //    if (users == null)
    //    {
    //        //broadcasting to everyone
    //        foreach (DictionaryEntry c in AllClients)
    //        {
    //            ((Client)(c.Value)).SendMessage(message + "\n");
    //        }
    //    }
    //    else
    //    {
    //        //broadcasting to selected ones
    //        foreach (DictionaryEntry c in AllClients)
    //        {
    //            foreach (string user in users)
    //            {
    //                if (((Client)(c.Value))._clientNick == user)
    //                {
    //                    ((Client)(c.Value)).SendMessage(message + "\n");
    //                    //log it locally
    //                    Console.WriteLine("sending-----> " + message);
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //}
    //private void ReceiveMessage(IAsyncResult ar)
    //{
    //    //read from client
    //    int bytesRead;
    //    try
    //    {
    //        lock (_client.GetStream())
    //        {
    //            bytesRead = _client.GetStream().EndRead(ar);
    //        }

    //        //client has disconnected
    //        if (bytesRead < 1)
    //        {
    //            AllClients.Remove(_clientIP);
    //            Broadcast("[Left][" + _clientNick + "] has left the chat.", null);
    //            return;
    //        }
    //        else
    //        {
    //            string messageReceived;
    //            int i = 0;
    //            int start = 0;

    //            //loop until no more chars
    //            while (data[i] != 0)
    //            {
    //                if (i + 1 > bytesRead)
    //                {
    //                    break;
    //                }

    //                //if LF DETECTED
    //                if (data[i] == LF)
    //                {
    //                    messageReceived = partialStr + System.Text.Encoding.ASCII.GetString(data, start, i - start);
    //                    Console.WriteLine("received <-----" + messageReceived);
    //                    if (messageReceived.StartsWith("[Join]"))
    //                    {
    //                        //client is sending its nickname
    //                        //e.g [Join][User1]

    //                        //extract user's name
    //                        int namelength = messageReceived.IndexOf("]", 6);
    //                        _clientNick = messageReceived.Substring(7, namelength - 7);

    //                        //tell everyone client has entered the chat.
    //                        Broadcast(messageReceived, null);
    //                    }
    //                    else if (messageReceived.StartsWith("[Usrs]"))
    //                    {
    //                        //client is requesting for all usernames

    //                        string allUsers = "[Usrs][";
    //                        foreach (DictionaryEntry c in AllClients)
    //                        {
    //                            //get all  the users name
    //                            allUsers += ((Client)(c.Value))._clientNick + ",";
    //                        }
    //                        allUsers += "]";
    //                        Broadcast(allUsers, null);

    //                    }
    //                    else if (messageReceived.StartsWith("[Talk]"))
    //                    {
    //                        string[] users = messageReceived.Substring(7, messageReceived.IndexOf("]", 7) - 8).Split(',');
    //                        Broadcast(messageReceived, users);
    //                    }
    //                    else if (messageReceived.StartsWith("[File]"))
    //                    {
    //                        string[] users = messageReceived.Substring(7, messageReceived.IndexOf("]", 7) - 8).Split(',');

    //                        int index = messageReceived.IndexOf("]", 7) + 2;

    //                        string filename = messageReceived.Substring(index, messageReceived.Length - index - 1);

    //                        string from = users[0];

    //                        for (int j = 0; j <= users.Length - 1; j++)
    //                        {
    //                            users[j - 1] = users[j];
    //                        }
    //                        users[users.Length - 1] = string.Empty;
    //                        Broadcast("[File][" + from + "][" + filename + "]", users);
    //                    }
    //                    else if (messageReceived.StartsWith("[Send_File]"))
    //                    {
    //                        string[] users = messageReceived.Substring(12, messageReceived.IndexOf("]", 12) - 12).Split(',');
    //                        string RecipientIP = string.Empty;

    //                        foreach (DictionaryEntry C in AllClients)
    //                        {
    //                            if (((Client)(C.Value))._clientNick == users[1])
    //                            {
    //                                RecipientIP = ((Client)(C.Value))._clientIP.Substring(0, _clientIP.IndexOf(":"));
    //                                break;
    //                            }
    //                        }
    //                        users[1] = string.Empty;
    //                        Broadcast("[Send_File][" + RecipientIP + "]", users);
    //                    }
    //                    start = i + 1;
    //                }
    //                i += 1;
    //            }
    //            if (start != i)
    //            {
    //                partialStr = System.Text.Encoding.ASCII.GetString(data, start, i - start);
    //            }

    //        }

    //        lock (_client.GetStream())
    //        {
    //            _client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(_client.ReceiveBufferSize), ReceiveMessage, null);
    //        }
    //    }
    //    catch (Exception)
    //    {

    //        AllClients.Remove(_clientIP);
    //        Broadcast("[Left][" + _clientNick + "] has left the chat", null);
    //    }
    //}
}