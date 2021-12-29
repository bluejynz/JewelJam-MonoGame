using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelJam
{
    class AssetManager
    {
        //vars
        ContentManager contentManager;

        //constructors
        public AssetManager(ContentManager content)
        {
            contentManager = content;
        }

        //methods
        public Texture2D LoadSprite(string assetName)
        {
            return contentManager.Load<Texture2D>(assetName);
        }

        public SpriteFont LoadFont(string assetName)
        {
            return contentManager.Load<SpriteFont>(assetName);
        }

        public void PlaySoundEffect(string assetName)
        {
            SoundEffect sound = contentManager.Load<SoundEffect>(assetName);
            sound.Play();
        }

        public void PlaySong(string assetName, bool repeat)
        {
            MediaPlayer.IsRepeating = repeat;
            MediaPlayer.Play(contentManager.Load<Song>(assetName));
        }

    }
}
