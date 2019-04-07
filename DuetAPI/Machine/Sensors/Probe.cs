﻿using System;

namespace DuetAPI.Machine
{
    /// <summary>
    /// Information about a configured probe
    /// </summary>
    public class Probe : ICloneable
    {
        /// <summary>
        /// Type of the configured probe
        /// </summary>
        /// <seealso cref="ProbeType"/>
        public ProbeType Type { get; set; }
        
        /// <summary>
        /// Current analog value of the probe
        /// </summary>
        public int Value { get; set; }
        
        /// <summary>
        /// Secondary value(s) of the probe
        /// </summary>
        public int[] SecondaryValues { get; set; }
        
        /// <summary>
        /// Configured trigger threshold (0..1023)
        /// </summary>
        public int Threshold { get; set; } = 500;
        
        /// <summary>
        /// Probe speed (in mm/s)
        /// </summary>
        public double Speed { get; set; } = 2;
        
        /// <summary>
        /// Dive height (in mm)
        /// </summary>
        public double DiveHeight { get; set; }
        
        /// <summary>
        /// Z height at which the probe is triggered (in mm)
        /// </summary>
        public double TriggerHeight { get; set; } = 0.7;        // mm
        
        /// <summary>
        /// Whether the probe signal is inverted
        /// </summary>
        public bool Inverted { get; set; }
        
        /// <summary>
        /// Recovery time (in s)
        /// </summary>
        public double RecoveryTime { get; set; }
        
        /// <summary>
        /// Travel speed when probing multiple points (in mm/s)
        /// </summary>
        public double TravelSpeed { get; set; } = 100.0;
        
        /// <summary>
        /// Maximum number of times to probe after a bad reading was determined
        /// </summary>
        public int MaxProbeCount { get; set; } = 1;
        
        /// <summary>
        /// Allowed tolerance deviation between two measures (in mm)
        /// </summary>
        public double Tolerance { get; set; } = 0.03;
        
        /// <summary>
        /// Whether probing disables the bed heater(s)
        /// </summary>
        public bool DisablesBed { get; set; }

        /// <summary>
        /// Creates a clone of this instance
        /// </summary>
        /// <returns>A clone of this instance</returns>
        public object Clone()
        {
            return new Probe
            {
                Type = Type,
                Value = Value,
                SecondaryValues = (int[])SecondaryValues.Clone(),
                Threshold = Threshold,
                Speed = Speed,
                DiveHeight = DiveHeight,
                TriggerHeight = TriggerHeight,
                Inverted = Inverted,
                RecoveryTime = RecoveryTime,
                TravelSpeed = TravelSpeed,
                MaxProbeCount = MaxProbeCount,
                Tolerance = Tolerance,
                DisablesBed = DisablesBed
            };
        }
    }
}