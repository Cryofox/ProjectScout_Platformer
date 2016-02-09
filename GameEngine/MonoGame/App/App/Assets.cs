using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    class Assets
    {
        //Paths for all Content

         const string ROOT = "Content/";
         const string DATA = "Assets/Data";
         const string SPRITE = "Assets/Sprites";
         const string AUDIO = "Assets/Audio";
         const string ICONS = "Assets/Icons";



        public const string PIXEL = SPRITE + "/Pixel";
        public const string TILESET = SPRITE+ "/OverWorldTileset";
        public const string HERO = SPRITE + "/Hero";

        //For Data that can't be interpreted through Content Pipeline append entire pathname

        public const string DATA_TESTROOM_PLATFORM =ROOT+ DATA+"/TRoom_PlatForms.tmx";
        public const string DATA_TESTROOM_MANEUVER = ROOT + DATA + "/TRoom_Maneuver.tmx";



        // Strings representing TileMap Terms
        public const string PLAYER_START = "Spawn";









    }
}
