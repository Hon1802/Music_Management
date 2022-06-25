using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
using TagLib;
//


namespace try19_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //spectrum
       

        private void Form1_Load(object sender, EventArgs e)
        {
            bunifuHSlider2.Value = maxvolume;


        }
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        string s;
        bool check_play = false;
        int maxvolume = 100;
        bool check_panel = true;
        int next = 0;
        int previous = 0;
        private void hide()
        {

        }
        private void runmp3(string lb)
        {
            player.URL = s;
            label2.Text = lb;
            player.controls.play();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog dlg = new OpenFileDialog();
        //    if(dlg.ShowDialog()==DialogResult.OK)
        //    {
        //        s = dlg.FileName;
        //        timer1.Enabled = true;
        //        runmp3();
                
        //    }
        //}

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void progressBar_temp(Object sender, EventArgs e)
        {
            if(player.playState ==WMPLib.WMPPlayState.wmppsPlaying)
            {
                //progressBar1.Maximum = (int)player.controls.currentItem.duration;
                //progressBar1.Value = (int)player.controls.currentPosition;
            }
        }

        private void progressBar1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuShapes3_ShapeChanged(object sender, Bunifu.UI.WinForms.BunifuShapes.ShapeChangedEventArgs e)
        {

        }

        private void bunifuShapes1_ShapeChanged(object sender, Bunifu.UI.WinForms.BunifuShapes.ShapeChangedEventArgs e)
        {
            player.controls.stop();
        }

        private void bunifuShapes5_ShapeChanged(object sender, Bunifu.UI.WinForms.BunifuShapes.ShapeChangedEventArgs e)
        {
            //label2.Text = player.status;
            if(player.status.ToLower().Contains("playing"))
            {
                player.controls.pause();
            }
            else
            {
                player.controls.play();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            label1.Text = player.controls.currentPositionString;
            bunifuHSlider1.Maximum = (int)player.controls.currentItem.duration;
            bunifuHSlider1.Value = (int)player.controls.currentPosition;
            bunifuHSlider2.Maximum = 100;

        }

        private void bunifuShapes2_Click(object sender, EventArgs e)
        {
            try
            {
                previous--;
                if (previous < 0)
                {
                    player.URL = filePaths[previous];
                    label2.Text = bunifuDataGridView1.Rows[previous].Cells[0].Value.ToString().Trim();
                    timer1.Enabled = true;
                    player.controls.play();
                }
                else
                {
                    player.URL = filePaths[bunifuDataGridView1.ColumnCount - 1];
                    label2.Text = bunifuDataGridView1.Rows[bunifuDataGridView1.ColumnCount - 1].Cells[0].Value.ToString().Trim();
                    timer1.Enabled = true;
                    player.controls.play();
                }

            }
            catch (Exception exp)
            {
                player.URL = s;
                timer1.Enabled = true;
                player.controls.play();
            }
            
        }
        public void newf(int index)
        {
            //string filePath = @"C:\temp\example.docx";
            //var file = ShellFile.FromFilePath(filePaths[0]);
            TagLib.File tagFile = TagLib.File.Create(filePaths[index]); //?taglib
            string artist = tagFile.Tag.FirstAlbumArtist;
            string album = tagFile.Tag.Album;
            string title = tagFile.Tag.Title;
            string times = Convert.ToDateTime( tagFile.Properties.Duration.ToString()).ToString("mm:ss");
            MessageBox.Show("artist"+artist + " album " + album + " title " + title +"Lyrics " +times);
        }

        private void bunifuShapes1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
        }

        private void bunifuShapes5_Click(object sender, EventArgs e)
        {
            if (player.status.ToLower().Contains("playing"))
            {
                player.controls.pause();
            }
            else
            {
                player.controls.play();
            }
        }

        private void bunifuHSlider1_ValueChanged(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ValueChangedEventArgs e)
        {
            if(check_play)
            {
                player.controls.currentPosition = bunifuHSlider1.Value;
                check_play = false;
            }
           
        }

        private void bunifuHSlider1_Click(object sender, EventArgs e)
        {
            check_play = true;
        }

        private void bunifuHSlider1_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            check_play = true;
        }

        private void bunifuShapes4_Click(object sender, EventArgs e)
        {
            if (player.settings.volume != 0)
            {
                player.settings.volume = 0;
                bunifuHSlider2.Value = 0;
            }
            else
            {
                player.settings.volume = 100;
                bunifuHSlider2.Value = 100;
            }

        }

        private void bunifuHSlider2_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            player.settings.volume = bunifuHSlider2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (check_panel)
            {
                panelmedia.Hide();
                check_panel = false;
            }
            else
            {
                panelmedia.Show();
                check_panel = true ;

            }
            //panelmedia.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                s = dlg.FileName;
                timer1.Enabled = true;
                runmp3(dlg.SafeFileName);
                //timer1.Enabled = false;

            }
        }

        string[] filePaths;
        string[] fileNames;
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Mp3 files, mp4 files (*.mp3, *.mp4)|*.mp*";
            dlg.Multiselect = true;
            dlg.Title = "Open";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePaths = dlg.FileNames;
                fileNames = dlg.SafeFileNames;
                int tee = 0;
                foreach(var item in fileNames)
                {
                    //bunifuDataGridView1.Rows[tee].Cells[0].Value = item;
                    string[] row = new string[] { item, "Unknow", "Unknow", "Unknow" };
                    bunifuDataGridView1.Rows.Add(row);
                    //tee++;
                }
            }

        }
       
        private void bunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int choose = Convert.ToInt32(bunifuDataGridView1.CurrentRow.Index);
            //add
            newf(choose);
            //add
            label2.Text = bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            next = choose;
            previous = choose;
            player.URL = filePaths[choose];
            //MessageBox.Show(bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
            timer1.Enabled = true;
            player.controls.play();
            //timer1.Enabled = true;
            
        }

        private void bunifuShapes3_Click(object sender, EventArgs e)
        {
            try
            {
                next++;
                if (next > bunifuDataGridView1.ColumnCount - 1)
                {
                    player.URL = filePaths[0];
                    label2.Text = bunifuDataGridView1.Rows[0].Cells[0].Value.ToString().Trim();
                    timer1.Enabled = true;
                    player.controls.play();
                }
                else
                {
                    player.URL = filePaths[next];
                    label2.Text = bunifuDataGridView1.Rows[next].Cells[0].Value.ToString().Trim();
                    timer1.Enabled = true;
                    player.controls.play();
                }

            } catch (Exception exp)
            {
                player.URL = s;
                timer1.Enabled = true;
                player.controls.play();
            }


            }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (var item in fileNames)
            {
                //if()
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hh");
            //newf();
        }
    }
    }



