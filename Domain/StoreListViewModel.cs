﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using hygge_imaotai.Entity;
using hygge_imaotai.Repository;
using hygge_imaotai.UserInterface.UserControls;

namespace hygge_imaotai.Domain
{
    /// <summary>
    /// 门店列表Page的ViewModel
    /// </summary>
    public class StoreListViewModel:ViewModelBase
    {
        #region Field
        private string _shopId;
        private string _province;
        private string _city;
        private string _area;
        private string _companyName;

        // 分页数据
        private int _total = 0;
        private int _current = 1;
        private int _pageSize = 10;
        private int _pageCount = 0;
        #endregion

        #region Properties

        public string ShopId
        {
            get => _shopId;
            set => SetProperty(ref _shopId, value);
        }

        public string Province
        {
            get => _province;
            set => SetProperty(ref _province, value);
        }

        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        public string Area
        {
            get => _area;
            set => SetProperty(ref _area, value);
        }

        public string CompanyName
        {
            get => _companyName;
            set => SetProperty(ref _companyName, value);
        }

        public static ObservableCollection<StoreEntity> StoreList { get; } = new ObservableCollection<StoreEntity>();

        public int Total
        {
            get => _total;
            set => SetProperty(ref _total, value);
        }

        public int Current
        {
            get => _current;
            set => SetProperty(ref _current, value);
        }

        public int PageSize
        {
            get => _pageSize;
            set => SetProperty(ref _pageSize, value);
        }

        public int PageCount
        {
            get => _pageCount;
            set => SetProperty(ref _pageCount, value);
        }

        #endregion

        #region Constructor

        public StoreListViewModel()
        {
            CurrentPageChangeCommand = new AnotherCommandImplementation(UpdateData);
        }
#endregion

        #region DelegateCommand
        public ICommand CurrentPageChangeCommand { get; private set; }
        private void UpdateData(object parameter)
        {
            StoreList.Clear();
            ShopRepository.GetPageData((int)parameter, 10,this).ForEach(StoreList.Add);
        }

        #endregion
    }
}
