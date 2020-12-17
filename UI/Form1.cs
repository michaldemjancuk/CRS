using Models.Download.Clans.CurrentRiverRace;
using Models.Download.Clans.Members;
using Models.Download.Players;
using StatsRetriever.Clans;
using StatsRetriever.Players;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
	public partial class Form1 : Form
	{
		_Members membersResponse;
		Response currentRiverRaceResponse;

		public Form1()
		{
			InitializeComponent();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(listBox1.SelectedItem.ToString()))
				return;
			Item player = membersResponse.Items[listBox1.SelectedIndex];

			DateTime lastSeen = DateTime.ParseExact(player.LastSeen, "yyyyMMddTHHmmss.fffZ", new CultureInfo("en-US"));
			Participant participantCW = currentRiverRaceResponse.Clan.Participants.Where(x => x.Tag == player.Tag).FirstOrDefault();
			textBox1.Text =
			$"Jméno: {player.Name + Environment.NewLine}" +
			$"Tag: {player.Tag + Environment.NewLine}" +
			$"Práva: {player.Role + Environment.NewLine}" +
			$"Naposledy online: {lastSeen.ToString() + Environment.NewLine}" +
			$"Úroveň: {player.ExpLevel + Environment.NewLine}" +
			$"Pohárky: {player.Trophies + Environment.NewLine}" +
			$"Aréna: {player.Arena.Name + Environment.NewLine}" +
			$"Clan Rank: {player.ClanRank}({player.PreviousClanRank}) {(player.PreviousClanRank - player.ClanRank) + Environment.NewLine}" +
			$"Donations [Got: {player.DonationsReceived}] [Sent: {player.Donations}] {Environment.NewLine}";
			if(participantCW != default(Participant))
			textBox1.Text += $"{Environment.NewLine}--- CLAN WAR ---{Environment.NewLine + Environment.NewLine}" +
			$"CW Bodů: {participantCW.Fame + Environment.NewLine}" +
			$"Útoků na loď: {participantCW.BoatAttacks + Environment.NewLine}" +
			$"Repair body: {participantCW.RepairPoints}";

			playerStatsButton.Visible = true;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (!VersionChecker.ActualVersion())
			{
				Process.Start("CRS Updater.exe");
				Close();
			}
			try
			{
				membersResponse = new Members().GetData();
				currentRiverRaceResponse = new CurrentRiverRace().GetData();

				foreach (Item member in membersResponse.Items)
				{
					listBox1.Items.Add($"[{member.Trophies}] \"{member.Name}\" - {member.Role}");
				}

				this.Text = $"{currentRiverRaceResponse.Clan.Name} - Statistics";
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Během získávání dat nastala neznámá chyba: " + Environment.NewLine + ex.Message,
					"Nastala chyba");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (toolStripComboBox1.SelectedIndex == -1)
			{
				MessageBox.Show(
					"Než aktualizuješ data, vyber prosím, koho chceš zobrazit!",
					"Nelze zobrazit data!"
				);
				return;
			} // Who
			if (toolStripComboBox2.SelectedIndex == -1)
			{
				MessageBox.Show(
					"Než aktualizuješ data, vyber prosím, v jakém pořadí chceš daata zobrazit!",
					"Nelze zobrazit data!"
				);
				return;
			} // Order

			try
			{
				membersResponse = new Members().GetData();
				currentRiverRaceResponse = new CurrentRiverRace().GetData();

				SortUsers();
				OrderUsers();

				listBox1.Items.Clear();
				playerStatsButton.Visible = false;
				textBox1.Text = string.Empty;
				foreach (Item member in membersResponse.Items)
				{
					listBox1.Items.Add($"[{member.Trophies}] \"{member.Name}\" - {member.Role.ToString()}");
				}

				this.Text = $"{currentRiverRaceResponse.Clan.Name} - Statistics";
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Během získávání dat nastala neznámá chyba: " + Environment.NewLine + ex.Message,
					"Nastala chyba");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("cmd", "/C start https://www.fb.me/CRStatsFree");
		}

		private void SortUsers()
		{
			switch (toolStripComboBox1.SelectedIndex)
			{
				case 0:	// All
					return;
				case 1: // ActiveCW
					membersResponse.Items = membersResponse.Items.Where(
						x => currentRiverRaceResponse.Clan.Participants.Any(
							y => 
								y.Tag == x.Tag &&
								( y.RepairPoints > 0 || y.BoatAttacks > 0 || y.Fame > 0)
						)
					).ToArray();
					return;
				case 2: // InactiveCW
					membersResponse.Items = membersResponse.Items.Where(
						x => !currentRiverRaceResponse.Clan.Participants.Any(
							y =>
								y.Tag == x.Tag &&
								(y.RepairPoints > 0 || y.BoatAttacks > 0 || y.Fame > 0)
						)
					).ToArray();
					return;
				default:
					MessageBox.Show(
						"Nastala chyba při třídění uživatel - Byla vybrána programově nemožná situace",
						"Nastala chyba"
					);
					return;
			}
		}

		private void OrderUsers()
		{
			switch (toolStripComboBox2.SelectedIndex)
			{
				case 0: // By trophies
					return;
				case 1: // By level
					membersResponse.Items = membersResponse.Items.OrderByDescending(x => x.ExpLevel).ToArray();
					return;
				case 2: // By name
					membersResponse.Items = membersResponse.Items.OrderBy(x => x.Name).ToArray();
					return;
				case 3: // By clan rank
					membersResponse.Items = membersResponse.Items.OrderBy(x => x.ClanRank).ToArray();
					return;
				case 4: // By donations sent
					membersResponse.Items = membersResponse.Items.OrderByDescending(x => x.Donations).ToArray();
					return;
				case 5: // By donations got
					membersResponse.Items = membersResponse.Items.OrderByDescending(x => x.DonationsReceived).ToArray();
					return;
				case 6: // By fame obtained
					currentRiverRaceResponse.Clan.Participants =
						currentRiverRaceResponse.Clan.Participants.OrderByDescending(x => x.Fame).ToArray();
					List<Item> protoItemList = new List<Item>();
					foreach (Participant participant in currentRiverRaceResponse.Clan.Participants)
					{
						if (membersResponse.Items.Any(x => x.Tag == participant.Tag))
							protoItemList.Add(membersResponse.Items.First(x => x.Tag == participant.Tag));
					}
					membersResponse.Items = protoItemList.ToArray();
					return;
				case 7: // By repair points obtained
					currentRiverRaceResponse.Clan.Participants =
						currentRiverRaceResponse.Clan.Participants.OrderByDescending(x => x.RepairPoints).ToArray();
					List<Item> protoItemList2 = new List<Item>();
					foreach (Participant participant in currentRiverRaceResponse.Clan.Participants)
					{
						if (membersResponse.Items.Any(x => x.Tag == participant.Tag))
							protoItemList2.Add(membersResponse.Items.First(x => x.Tag == participant.Tag));
					}
					membersResponse.Items = protoItemList2.ToArray();
					return;
				case 8: // By boat attacks
					currentRiverRaceResponse.Clan.Participants =
						currentRiverRaceResponse.Clan.Participants.OrderByDescending(x => x.BoatAttacks).ToArray();
					List<Item> protoItemList3 = new List<Item>();
					foreach (Participant participant in currentRiverRaceResponse.Clan.Participants)
					{
						if (membersResponse.Items.Any(x => x.Tag == participant.Tag))
							protoItemList3.Add(membersResponse.Items.First(x => x.Tag == participant.Tag));
					}
					membersResponse.Items = protoItemList3.ToArray();
					return;
				default:
					MessageBox.Show(
						"Nastala chyba při třídění uživatel - Byla vybrána programově nemožná situace",
						"Nastala chyba"
					);
					return;
			}
		}

		private void playerStatsButton_Click(object sender, EventArgs e)
		{

			try
			{
				_Players playerData =  new Players().GetData(membersResponse.Items[listBox1.SelectedIndex].Tag);
				UserStats userStats = new UserStats(playerData);
				userStats.Show(this);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Během získávání dat nastala neznámá chyba: " + Environment.NewLine + ex.Message,
					"Nastala chyba");
			}
		}
	}
}
