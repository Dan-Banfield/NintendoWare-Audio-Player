﻿using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using NintendoWare_Audio_Player.Storage;
using NintendoWare_Audio_Player.Audio;

namespace NintendoWare_Audio_Player.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void MainForm_Load(object sender, System.EventArgs e)
            => LoadSaveData();

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            => SaveSystem.SaveCurrentData();

        private void openToolStripMenuItem_Click(object sender, System.EventArgs e)
            => OpenAudioFile();

        private void audioListView_DoubleClick(object sender, System.EventArgs e)
        {
            if (audioListView.SelectedItems.Count == 0) return;

            AudioPlayer.PlayBFSTMFile(audioListView.SelectedItems[0]
                .SubItems[1].Text);
        }

        #endregion

        #region Methods

        private void LoadSaveData()
        {
            PopulateAudioListView(SaveSystem.saveDataInstance.audioFileData);
        }

        private void PopulateAudioListView(Dictionary<string, string> dictionary)
        {
            audioListView.Items.Clear();
            foreach (KeyValuePair<string, string> keyValuePair
                in SaveSystem.saveDataInstance.audioFileData)
            {
                ListViewItem listViewItem = new ListViewItem(keyValuePair.Key);
                listViewItem.SubItems.Add(keyValuePair.Value);
                audioListView.Items.Add(listViewItem);
            }
        }

        private void OpenAudioFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select NintendoWare Audio Files";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    int length = ofd.FileNames.Length;

                    for (int i = 0; i < length; i++)
                    {
                        try
                        {
                            SaveSystem.saveDataInstance.audioFileData.Add
                            (Path.GetFileName(ofd.FileNames[i]), ofd.FileNames[i]);
                        }
                        catch { }
                    }

                    PopulateAudioListView(SaveSystem.saveDataInstance.audioFileData);
                }
            }
        }

        #endregion
    }
}