﻿using System;
using SQLite;
using TripInside.Model;
using Xamarin.Forms;

namespace TripInside.Models.DBModels
{
    [Table("Trip")]
    public class Trip : BaseModel
    {
        private int _id;
        private string _name;
        private string _nationalCode;
        private string _nationalName;
        private Image _nationalFlag;
        private DateTime _fromDate;
        private DateTime _toDate;
        private DateTime _createDate;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        [NotNull]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        [NotNull]
        public string NationalCode
        {
            get
            {
                return _nationalCode;
            }
            set
            {
                _nationalCode = value;
                OnPropertyChanged();
            }
        }

		[NotNull]
		public string NationalName
		{
			get
			{
                return _nationalName;
			}
			set
			{
				_nationalName = value;
				OnPropertyChanged();
			}
		}

		[NotNull]
        public Image NationalFlag
		{
			get
			{
                return _nationalFlag;
			}
			set
			{
				_nationalFlag = value;
				OnPropertyChanged();
			}
		}

        [NotNull]
        public DateTime FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                _fromDate = value;
                OnPropertyChanged();
            }
        }

        [NotNull]
        public DateTime ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                _toDate = value;
                OnPropertyChanged();
            }
        }

        public string DurationString
		{
			get
			{
                return string.Format("{0} ~ {1}", _fromDate.ToString("yyyy.MM.dd"), _toDate.ToString("yyyy.MM.dd"));
			}
		}

        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
                OnPropertyChanged();
            }
        }
    }
}