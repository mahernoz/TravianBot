using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TravianBot.Utilities;

namespace TravianBot.UI.Controls
{
    public partial class VillageProfilesControl : UserControl
    {
        public VillageProfilesControl()
        {
            InitializeComponent();
            Profiles.ForEach(i => { profileComboBox.Items.Add(i); });
        }

        /// <summary>
        ///     Gets village profiles.
        /// </summary>
        private List<VillageProfile> Profiles
        {
            get { return Travian.Instance.Profiles; }
        }

        /// <summary>
        ///     Handles create profile button click events.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event args.</param>
        private void createProfileBtn_Click(object sender, EventArgs e)
        {
            var name = profileNameTxtBox.Text;

            if (Profiles.Exists(i => i.Name.Equals(name)))
            {
                MessageBox.Show(
                    "A profile with this name exists.",
                    "Error. Can't create.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var vp = new VillageProfile(name);
            Profiles.Add(vp);
        }

        /// <summary>
        ///     Handles remove button click events.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event args.</param>
        private void removeBtn_Click(object sender, EventArgs e)
        {
            var vp = profileComboBox.SelectedItem as VillageProfile;

            if (vp == null)
            {
                return;
            }

            profileComboBox.Items.Remove(vp);
        }

        /// <summary>
        ///     Handles add button click events.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event args.</param>
        private void addBtn_Click(object sender, EventArgs e)
        {
        }

        private void SaveProfiles()
        {
            SerializeHelper.WriteToXmlFile("profiles.xml", Profiles);
        }

        private void LoadProfiles()
        {
        }
    }
}