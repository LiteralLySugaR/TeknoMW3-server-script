using System;
using System.Collections.Generic;
using System.IO;
using InfinityScript;

namespace InfectedServerSsa
{
    internal class ConLog : BaseScript
    {
        //So... i think this is the final version or improvement of this part,
        //why did i event did that? in case if some moders/admins will lie to higher ranks
        //about "dude, he said he's cheating" but in fact the guy was banned in the
        //middle of playing and said nothing before.
        //Or this situation: a guy was banned from the server. You don't know who banned,
        //but this script will show all info.

        //Inproved: Ban Event. Now every single ban event is now in PlayerBannedEv
        //and now they are distributed by types (Entity banned, Entity inflictor, string reason, int type)


        //On player send message in chat (work even with commands that were hidded from chat)
        internal void PlayerMessageEv(Entity player, string message, string Pcase)
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
            sw.WriteLine("[" + DateTime.Now + "] " + $"{player.Name + "[" + Pcase + "]"}" + ": " + message);
            sw.Flush();
            sw.Close();
        }
        //Player connected
        internal void PlayerConnectingEv(Entity player, params object[] p)
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
            Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") connected", p);
            //Log.Write(LogLevel.All, "[LOG] Client size: " + Entitys.Count, p);
            sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") connected");
            //sw.WriteLine("[" + DateTime.Now + "] Client size: " + Entitys.Count);
            sw.Flush();
            sw.Close();
        }
        //Player disconnected
        internal void PlayerDisconnectingEv(Entity player, params object[] p)
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
            Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") disconnected", p);
            //Log.Write(LogLevel.All, "[LOG] Client size: " + Entitys.Count, p);
            sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") disconnected");
            //sw.WriteLine("[" + DateTime.Now + "] Client size: " + Entitys.Count);
            sw.Flush();
            sw.Close();
        }
        //Player got banned
        internal void PlayerBannedEv(Entity player, Entity inflictor, string strArray, int type, params object[] p)
        {
            //type1 = PERMBAN
            //type2 = TEMPBAN
            //type3 = IPBAN
            //type4 = DATABAN (event-ban)

            if (type == 1)
            {
                StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
                Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") banned by: " + inflictor.Name + " HWID(" + inflictor.HWID + ").", p);
                Log.Write(LogLevel.All, "[LOG] Reason: " + strArray, p);
                sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") banned by: " + inflictor.Name + " HWID(" + inflictor.HWID + ").");
                sw.WriteLine("[" + DateTime.Now + "] " + "Reason: " + strArray);
                sw.Flush();
                sw.Close();
            }
            if (type == 2)
            {
                StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
                Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") Temp-Banned by: " + inflictor.Name + " HWID(" + inflictor.HWID + ").", p);
                Log.Write(LogLevel.All, "[LOG] Reason: " + strArray, p);
                sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") Temp-Banned by: " + inflictor.Name + " HWID(" + inflictor.HWID + ").");
                sw.WriteLine("[" + DateTime.Now + "] " + "Reason: " + strArray);
                sw.Flush();
                sw.Close();
            }
            if (type == 3)
            {
                StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
                Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") IP-Banned by: " + inflictor.Name + " HWID(" + inflictor.HWID + ").", p);
                Log.Write(LogLevel.All, "[LOG] Player IP: " + player.IP.Address, p);
                sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") IP-Banned by: " + inflictor.Name + " HWID(" + inflictor.HWID + ").");
                sw.WriteLine("[" + DateTime.Now + "] Player IP: " + player.IP.Address);
                sw.Flush();
                sw.Close();
            }
            if (type == 4)
            {
                StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
                Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") Event-Banned by: " + inflictor.Name + " HWID(" + inflictor.HWID + ").", p);
                sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") Event-Banned by: " + inflictor.Name + " HWID(" + inflictor.HWID + ").");
                sw.Flush();
                sw.Close();
            }
        }
        //Player got kicked
        internal void PlayerKicked(Entity player, Entity inflictor, string strArray, params object[] p)
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
            Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") kicked by: " + inflictor.Name + " HWID(" + inflictor.HWID + ").", p);
            Log.Write(LogLevel.All, "[LOG] Reason: " + strArray, p);
            sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") kicked by: " + inflictor.Name + " HWID(" + inflictor.HWID + ").");
            sw.WriteLine("[" + DateTime.Now + "] " + "Reason: " + strArray);
            sw.Flush();
            sw.Close();
        }
        //idk why but just in case... xD
        internal void PlayerUnbanEv(Entity player, string str, params object[] p)
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
            Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") Unban: " + str, p);
            sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") Unban: " + str);
            sw.Flush();
            sw.Close();
        }
        //Player change map
        internal void PlayerMapEv(Entity player, string str, params object[] p)
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
            Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") Changed map: " + str, p);
            sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") Changed map: " + str);
            sw.Flush();
            sw.Close();
        }
        //Player use command (no args on other player)
        internal void PlayerUseCommandEv(Entity player, string str, params object[] p)
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
            Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") used command: " + str, p);
            sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") used command: " + str);
            sw.Flush();
            sw.Close();
        }
        //Player use command on someone
        internal void PlayerUseCommandOnEv(Entity player, string str, Entity inflictor, params object[] p)
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
            Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") used command: " + str + " on " + inflictor.Name + " HWID(" + inflictor.HWID + ").", p);
            sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") used command: " + str + " on " + inflictor.Name + " HWID(" + inflictor.HWID + ").");
            sw.Flush();
            sw.Close();
        }
        //Player got killed by TriggerKill
        internal void PlayerTriggerKillEv(Entity player, string map, params object[] p)
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
            Log.Write(LogLevel.All, "[LOG] " + player.Name + " HWID(" + player.HWID + ") Died from TriggerKill on map " + map, p);
            sw.WriteLine("[" + DateTime.Now + "] " + player.Name + " HWID(" + player.HWID + ") Died from TriggerKill on map " + map);
            sw.Flush();
            sw.Close();
        }
        internal void StringArray(string strArray, params object[] p)
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt", true);
            sw.WriteLine("[" + DateTime.Now + "] " + strArray);
            sw.Flush();
            sw.Close();
        }
        //internal void LogCleaner()
        //{
        //    string[] lines = File.ReadAllLines("scripts\\GPIv3\\Logss.txt");
        //    for (int i = 0; i < 500; i++)
        //    {
        //        lines[i].Remove(0);
        //    }
        //    //int rowNumber = 2;
        //    //string[] rows = File.ReadAllLines("scripts\\GPIv3\\Log.txt");
        //    //StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Log.txt");
        //    //for (int i = 0; i < rows.Length; i++)
        //    //{
        //    //    if (i != rowNumber)
        //    //    {
        //    //        sw.WriteLine(rows[i]);
        //    //    }
        //    //}
        //    //sw.Close();
        //}
    }
}
