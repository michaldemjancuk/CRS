using Models.Download.Players;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
	public partial class UserStats : Form
	{
		_Players PlayerData;
		List<string> ImagesToLoad = new List<string>();

		public UserStats(_Players playerData)
		{
			PlayerData = playerData;
			InitializeComponent();
		}

		private void UserStats_Load(object sender, EventArgs e)
		{
			Text = $"{PlayerData.name} [{PlayerData.clan.name}]";
			dataGridView1.RowTemplate.Height = 75;
			dataGridView1.Rows.Add(PlayerData.cards.Count);
			PlayerData.cards = PlayerData.cards.OrderByDescending(x => 13 - x.maxLevel + x.level).ThenByDescending(x => x.count).ToList();
			for (int i = 0; i < PlayerData.cards.Count; i++)
			{
				Card card = PlayerData.cards[i];
				DataGridViewRow dataRow = dataGridView1.Rows[i];
				dataRow.Cells["Name"].Value = card.name;
				dataRow.Cells["Level"].Value = 13 - card.maxLevel + card.level;
				dataRow.Cells["Count"].Value = card.count;
				ImagesToLoad.Add(card.iconUrls?.medium ?? "");
			}
			double winrate = 100 * PlayerData.wins / (double)(PlayerData.wins + PlayerData.losses);
			LoadProperties(
				new List<KeyValuePair<string, string>>()
				{
					new KeyValuePair<string, string>("Jméno:", PlayerData.name),
					new KeyValuePair<string, string>("Tag:", PlayerData.tag),
					new KeyValuePair<string, string>("Clan:", PlayerData.clan.name),
					new KeyValuePair<string, string>("Clan tag:", PlayerData.clan.tag),
					new KeyValuePair<string, string>("Úroveň:", PlayerData.expLevel.ToString()),
					new KeyValuePair<string, string>("Pohárky:", PlayerData.trophies.ToString()),
					new KeyValuePair<string, string>("Nejvíce pohárků:", PlayerData.bestTrophies.ToString()),
					new KeyValuePair<string, string>("Donations v tomto týdnu [Odesláno|Získáno]:", $"[ {PlayerData.donations} | {PlayerData.donationsReceived} ]"),
					new KeyValuePair<string, string>("Donations darováno celkem:", PlayerData.totalDonations.ToString()),
					new KeyValuePair<string, string>("Procento výher [Výhry/Prohry]:", $"{winrate:F}% [ {PlayerData.wins} / {PlayerData.losses} ]"),
				}
			);
			new Task(new Action(LoadImages)).Start();
		}

		private void LoadImages()
		{
			for (int i = 0; i < ImagesToLoad.Count; i++)
			{
				try
				{
					HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(ImagesToLoad[i]);
					imageRequest.Method = "GET";
					HttpWebResponse imageResponse = (HttpWebResponse)imageRequest.GetResponse();
					Bitmap bmp = new Bitmap(imageResponse.GetResponseStream());
					bmp = new Bitmap(bmp, new Size(bmp.Width / 4, bmp.Height / 4));
					imageResponse.Close();

					dataGridView1.Rows[i].Cells["Image"].Value = bmp;
				}
				catch (Exception ex)
				{
					ImagesToLoad = new List<string>();
					MessageBox.Show("Nastala chyba během načítání obrázků karet" + Environment.NewLine + ex.Message);
					return;
				}
			}
			ImagesToLoad = new List<string>();
		}

		private void LoadProperties(List<KeyValuePair<string, string>> properties)
		{
			dataGridView2.Rows.Add(properties.Count);
			for (int i = 0; i < properties.Count; i++)
			{
				dataGridView2.Rows[i].Cells["Property"].Value = properties[i].Key;
				dataGridView2.Rows[i].Cells["Value"].Value = properties[i].Value;
			}
		}
	}
}
