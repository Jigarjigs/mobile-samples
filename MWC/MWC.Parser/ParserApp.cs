﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MWC.BL;
using System.Xml.Serialization;

namespace MWC.Parser
{
	public class ParserApp
	{
		public void WriteConferenceXML(string path)
		{
			Console.WriteLine("Starting the parser...");
			Conference conf = ConferenceManager.GetConference();

			Console.WriteLine(string.Concat(conf.Sessions.Count, " sessions"));
			Console.WriteLine(string.Concat(conf.Speakers.Count, " speakers"));
			Console.WriteLine(string.Concat(conf.Exhibitors.Count, " exhibitors"));

			using(TextWriter tw = File.CreateText(Path.Combine(path, "Conference.xml")))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Conference));
				serializer.Serialize(tw, conf);
			}

			using(TextWriter tw = File.CreateText(Path.Combine(path, "MWC.html")))
			{
				tw.Write(DateTime.Now.ToString());
			}
		}
	}
}