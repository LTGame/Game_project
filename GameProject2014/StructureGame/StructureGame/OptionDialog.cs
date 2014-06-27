using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace StructureGame
{
    public class OptionDialog : Dialog
    {
        MenuItem de, trungbinh, kho, yeu, vua, manh, yeu_sound, vua_sound, manh_sound;
        KeyboardHelper exit;

        public void ClickDe()
        {
            GameManager.level = "de";
            GameManager.nCols = 10;
            GameManager.nRows = 10;
            GameManager.nObject = 10;
            GameManager.nTreasure = 5;
        }

        public void ClickTrungbinh()
        {
            GameManager.level = "trungbinh";
            GameManager.nCols = 15;
            GameManager.nRows = 15;
            GameManager.nObject = 20;
            GameManager.nTreasure = 10;
        }

        public void ClicKho()
        {
            GameManager.level = "kho";
            GameManager.nCols = 20;
            GameManager.nRows = 20;
            GameManager.nObject = 40;
            GameManager.nTreasure = 25;
        }

        public void ClickYeu()
        {
            GameManager.music = "yeu";
            GameManager.volume = 0.3f;
            MediaPlayer.Volume = 0.3f;
        }

        public void ClickVua()
        {
            GameManager.music = "vua";
            MediaPlayer.Volume = 0.5f;
        }

        public void ClickManh()
        {
            GameManager.music = "manh";
            MediaPlayer.Volume = 1f;
        }

        public void ClickYeu_sound()
        {
            GameManager.sound = "yeu";
            GameManager.volumeSound = 0.3f;
            GameManager.coin.Play(0.3f, 0, 0);
        }

        public void ClickVua_sound()
        {
            GameManager.sound = "vua";
            GameManager.volumeSound = 0.5f;
            GameManager.coin.Play(0.5f, 0, 0);
        }

        public void ClickManh_sound()
        {
            GameManager.sound = "manh";
            GameManager.volumeSound = 1f;
            GameManager.coin.Play(1f, 0, 0);
        }

        public OptionDialog()
        {
            exit = new KeyboardHelper(Keys.Escape);
            this.currentSprite = GameManager.spriteProvider.getSprite("Option");

            de = new MenuItem(Vector2.Zero, ClickDe, GameManager.spriteProvider.getSprite("De"), GameManager.spriteProvider.getSprite("De"), GameManager.spriteProvider.getSprite("De_active"), 0.01f);
            list_entity_dialog.Add(de);
            kho = new MenuItem(Vector2.Zero, ClicKho, GameManager.spriteProvider.getSprite("Kho"), GameManager.spriteProvider.getSprite("Kho"),GameManager.spriteProvider.getSprite("Kho_active"), 0.01f);
            list_entity_dialog.Add(kho);
            trungbinh = new MenuItem(Vector2.Zero, ClickTrungbinh, GameManager.spriteProvider.getSprite("TrungBinh"), GameManager.spriteProvider.getSprite("TrungBinh"), GameManager.spriteProvider.getSprite("TrungBinh_active"), 0.01f);
            list_entity_dialog.Add(trungbinh);

            yeu = new MenuItem(Vector2.Zero, ClickYeu, GameManager.spriteProvider.getSprite("Yeu"), GameManager.spriteProvider.getSprite("Yeu"),GameManager.spriteProvider.getSprite("Yeu_active"), 0.01f);
            list_entity_dialog.Add(yeu);
            vua = new MenuItem(Vector2.Zero, ClickVua, GameManager.spriteProvider.getSprite("Vua"), GameManager.spriteProvider.getSprite("Vua"),GameManager.spriteProvider.getSprite("Vua_active"), 0.01f);
            list_entity_dialog.Add(vua);
            manh = new MenuItem(Vector2.Zero, ClickManh, GameManager.spriteProvider.getSprite("Manh"), GameManager.spriteProvider.getSprite("Manh"), GameManager.spriteProvider.getSprite("Manh_active"), 0.01f);
            list_entity_dialog.Add(manh);

            yeu_sound = new MenuItem(Vector2.Zero, ClickYeu_sound, GameManager.spriteProvider.getSprite("Yeu_sound"), GameManager.spriteProvider.getSprite("Yeu_sound"),GameManager.spriteProvider.getSprite("Yeu_sound_active"), 0.01f);
            list_entity_dialog.Add(yeu_sound);
            vua_sound = new MenuItem(Vector2.Zero, ClickVua_sound, GameManager.spriteProvider.getSprite("Vua_sound"), GameManager.spriteProvider.getSprite("Vua_sound"), GameManager.spriteProvider.getSprite("Vua_sound_active"), 0.01f);
            list_entity_dialog.Add(vua_sound);
            manh_sound = new MenuItem(Vector2.Zero, ClickManh_sound, GameManager.spriteProvider.getSprite("Manh_sound"), GameManager.spriteProvider.getSprite("Manh_sound"),GameManager.spriteProvider.getSprite("Manh_sound_active"), 0.01f);
            list_entity_dialog.Add(manh_sound);

            this.currentSprite.Entity = this;
            this.depth = 0.02f;

            handler = new ContextEventHandler(list_entity_dialog);
        }

        public override void Update(GameTime gameTime)
        {
            exit.Update(gameTime);
            if (exit.HasKeyDown())
            {
                GameManager.currentScreen.Dialog = null;
                return;
            }
            if (GameManager.level.Equals("de"))
            {
                de.Active = true;
                trungbinh.Active = false;
                kho.Active = false;
            }
            else if (GameManager.level.Equals("trungbinh"))
            {
                de.Active = false;
                trungbinh.Active = true;
                kho.Active = false;
            }
            else
            {
                de.Active = false;
                trungbinh.Active = false;
                kho.Active = true;
            }

            if (GameManager.music.Equals("yeu"))
            {
                yeu.Active = true;
                vua.Active = false;
                manh.Active = false;
            }
            else if (GameManager.music.Equals("vua"))
            {
                yeu.Active = false;
                vua.Active = true;
                manh.Active = false;
            }
            else
            {
                yeu.Active = false;
                vua.Active = false;
                manh.Active = true;
            }

            if (GameManager.sound.Equals("yeu"))
            {
                yeu_sound.Active = true;
                vua_sound.Active = false;
                manh_sound.Active = false;
            }
            else if (GameManager.sound.Equals("vua"))
            {
                yeu_sound.Active = false;
                vua_sound.Active = true;
                manh_sound.Active = false;
            }
            else
            {
                yeu_sound.Active = false;
                vua_sound.Active = false;
                manh_sound.Active = true;
            }

            base.Update(gameTime);
        }
    }
}
