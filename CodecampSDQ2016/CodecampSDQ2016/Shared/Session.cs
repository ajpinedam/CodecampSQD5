﻿using System;

namespace CodecampSDQ2016
{
	public class Session
	{
	    public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int SpeakerId { get; set; }

        public string Charla { get; set; }

		public string Charlista { get; set; }

		public string Lugar { get; set; }

		public string HoraInicio { get; set; }
	}
}

