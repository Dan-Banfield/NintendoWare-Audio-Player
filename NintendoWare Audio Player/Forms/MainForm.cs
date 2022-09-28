using System.Windows.Forms;
using System.Collections.Generic;
using NintendoWare_Audio_Player.Storage;

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
        {
            LoadSaveData();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSystem.SaveCurrentData();
        }

        #endregion

        #region Methods

        public void LoadSaveData()
        {
            foreach (KeyValuePair<string, string> keyValuePair
                in SaveSystem.saveDataInstance.audioFileData)
            {
                PopulateAudioListView(keyValuePair.Key, keyValuePair.Value);
            }
        }

        public void PopulateAudioListView(string name, string path)
        {
            ListViewItem listViewItem = new ListViewItem(name);
            listViewItem.SubItems.Add(path);
            audioListView.Items.Add(listViewItem);
        }

        #endregion
    }
}