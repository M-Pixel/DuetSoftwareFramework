﻿namespace DuetAPI.Machine
{
    /// <summary>
    /// Calibration results (for Delta calibration)
    /// </summary>
    public sealed class MoveCalibrationResults : ModelObject
    {
        /// <summary>
        /// RMS deviation (in mm)
        /// </summary>
        public float Deviation
        {
            get => _deviation;
			set => SetPropertyValue(ref _deviation, value);
        }
        private float _deviation;

        /// <summary>
        /// Mean deviation (in mm)
        /// </summary>
        public float Mean
        {
            get => _mean;
			set => SetPropertyValue(ref _mean, value);
        }
        private float _mean;
    }
}
