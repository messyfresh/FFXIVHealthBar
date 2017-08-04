using System;
using System.Timers;
using System.IO;
using System.IO.Ports;

namespace FFXIVHP
{

	public class Program
    {
		// Instantiate Serial Port
		private static Serial serial = new Serial("COM4", 9600);

		private static FFXIV ffxiv = new FFXIV();

		static void Main(string[] args)
        {

			if (ffxiv._initiated == true)
			{
				if (serial._initiated == true)
				{
					Timer hpTimer = new Timer();
					hpTimer.Elapsed += new ElapsedEventHandler(GetConsoleHP);
					hpTimer.Interval = 1000;
					hpTimer.Enabled = true;
					hpTimer.Start();
				}
			}
			Console.ReadKey();
		}

		/*
		public void TimeHP()
		{
			Console.WriteLine("Starting Timer");
			System.Timers.Timer hpTimer = new System.Timers.Timer();
			hpTimer.Elapsed += new ElapsedEventHandler(GetConsoleHP);
			hpTimer.Interval = 100;
			hpTimer.Enabled = true;
			hpTimer.Start();

			GC.KeepAlive(hpTimer);
			Console.Read();

		}
		*/
		private static void GetConsoleHP(object source, ElapsedEventArgs e)
		{
			// Clear the Console
			Console.Clear();
			// FFXIV Vars
			string firstName = "Messy";
			string lastName = "Fresh";

			FFXIV.Character charInfo = new FFXIV.Character(firstName, lastName);

			double hpCurrent = charInfo.stats.HPCurrent;
			double hpMax = charInfo.stats.HPMax;
			Console.WriteLine("Current HP: " + hpCurrent);
			Console.WriteLine("Max HP: " + hpMax);

			double healthPercent = (hpCurrent / hpMax);
			double healthLvl = healthPercent * 10;
			int roundedHealthLvl = (int)Math.Round(healthLvl, 0, MidpointRounding.AwayFromZero);

			Console.WriteLine("Health Percent: " + healthPercent);
			Console.WriteLine("Health Lvl: " + healthLvl);
			Console.WriteLine("Rounded Health Lvl: " + roundedHealthLvl);

			serial.SendMessage(roundedHealthLvl);

		}
	}
}
