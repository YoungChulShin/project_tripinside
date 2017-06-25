﻿using System;
using System.Windows.Input;
using TripInside.Model;
using TripInside.View.Trip;
using Xamarin.Forms;
using TripInside.Database;

namespace TripInside.ViewModel.Trip
{
    public class CreateTripViewModel : BaseViewModel
    {
        private string _tripName;
        private INavigation _navigation;
        private ImageSource _nationalFlag;
        private string _nationalCode;
        private string _nationalName;
        private DateTime _fromDate = DateTime.Now;
        private DateTime _toDate = DateTime.Now.AddDays(7);
        public CreateTripViewModel(INavigation navigaion)
        {
            _navigation = navigaion;    
        }

        public string TripName
        {
            get
            {
                return _tripName;
            }
            set
            {
                _tripName = value;
                OnPropertyChanged();
            }
        }

        public DateTime FromDate
        {
            get
            {
                return _fromDate;
            }
        }
		public DateTime ToDate
		{
			get
			{
                return _toDate;
			}
		}

        public ImageSource NationalFlag
        {
            get
            {
                return _nationalFlag;    
            }
            set
            {
                _nationalFlag = value;
                OnPropertyChanged("NationalFlag");
            }
        }

        public string NationalName
        {
            get
            {
                return _nationalName;
            }
            set
            {
                _nationalName = value;
                OnPropertyChanged("");
            }
        }

		public ICommand CreateTrip
		{
			get
			{
                return new Command(async() =>
                {
					TripDataAccess.SaveTrip(new Model.Trip()
					{
						Name = _tripName,
                        NationalCode = _nationalCode,
                        NationalName = _nationalName,
                        NationalFlag = _nationalFlag,
						FromDate = _fromDate,
						ToDate = _toDate,
						CreateDate = DateTime.Now
					});

                    await _navigation.PopModalAsync();
                });
			}
		}

		public ICommand CancelCreateTrip
		{
			get
			{
				return new Command(async () =>
                {
                    await _navigation.PopModalAsync();
				});
			}
		}
        public ICommand ViewNationalList
        {
            get
            {
				return new Command(async () =>
				{
                    NationalListView view = new NationalListView();

                    await _navigation.PushModalAsync(view);
                    await view.PageClosedTask;

                    _nationalCode = view.SelectedItem.Code;
                    NationalName = view.SelectedItem.Name;
                    NationalFlag = view.SelectedItem.Flag;
				});
            }
        }
    }
}