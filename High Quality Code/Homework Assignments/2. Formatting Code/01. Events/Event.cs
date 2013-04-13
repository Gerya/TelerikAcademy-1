﻿namespace Events
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// A class which represents an event (conference, meeting, lunch, etc.).
    /// </summary>
    public class Event : IComparable
    {
        #region Private Fields

        private DateTime dateAndTime;
        private string title;
        private string location;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="dateAndTime">The date and time of the event.</param>
        /// <param name="title">The title of the event.</param>
        /// <param name="location">The location of the event.</param>
        public Event(DateTime dateAndTime, string title, string location)
        {
            this.DateAndTime = dateAndTime;
            this.Title = title;
            this.Location = location;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets/sets the date and time of the event.
        /// </summary>
        /// <value>Serves as a wrapper of the dateAndTime field.</value>
        public DateTime DateAndTime
        {
            get { return this.dateAndTime; }
            private set { this.dateAndTime = value; }
        }

        /// <summary>
        /// Gets/sets the title of the event.
        /// </summary>
        /// <value>Serves as a wrapper of the title field.</value>
        public string Title
        {
            get { return this.title; }
            private set { this.title = value; }
        }

        /// <summary>
        /// Gets/sets the location of the event.
        /// </summary>
        /// <value>Serves as a wrapper of the location field.</value>
        public string Location
        {
            get { return this.location; }
            private set { this.location = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Overrides the <see cref="System.IComparable"/> method.
        /// </summary>
        /// <param name="obj">The object to compare this instance with.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Event other = obj as Event;
            if (other != null)
            {
                int byDateAndTime = this.DateAndTime.CompareTo(other.DateAndTime);
                int byTitle = this.Title.CompareTo(other.Title);
                int byLocation = this.Location.CompareTo(other.Location);

                if (byDateAndTime == 0)
                {
                    if (byTitle == 0)
                    {
                        return byLocation;
                    }
                    else
                    {
                        return byTitle;
                    }
                }
                else
                {
                    return byDateAndTime;
                }
            }
            else
            {
                throw new ArgumentException("Object is not an Event.");
            }
        }

        /// <summary>
        /// Returns event data in the following format:
        /// {Date and Time} | {Title} [| {Location}]
        /// </summary>
        /// <returns>The event data as a string.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(this.DateAndTime.ToString("yyyy-MM-ddTHH:mm:ss"));

            stringBuilder.Append(" | " + this.Title);

            if (!string.IsNullOrWhiteSpace(this.Location))
            {
                stringBuilder.Append(" | " + this.Location);
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}
