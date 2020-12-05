using Models.Download.Clans.CurrentRiverRace;
using Models.Download.Clans.Members;
using StatsRetriever.Clans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				membersResponse = new Members().GetData();
				currentRiverRaceResponse = new CurrentRiverRace().GetData();
				listBox1.Items.Clear();

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
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				membersResponse = new Members().GetData();
				currentRiverRaceResponse = new CurrentRiverRace().GetData();

				foreach (Item member in membersResponse.Items)
				{
					listBox1.Items.Add($"[{member.Trophies}] \"{member.Name}\" - {member.Role.ToString()}");
				}

				this.Text = $"{currentRiverRaceResponse.Clan.Name} - Statistics";

				button1.Enabled = true;
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
