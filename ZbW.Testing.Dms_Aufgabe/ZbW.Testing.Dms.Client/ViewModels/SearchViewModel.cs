namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Repositories;
    using ZbW.Testing.Dms.Client.Services;

    internal class SearchViewModel : BindableBase
    {
        private List<MetadataItem> _filteredMetadataItems;

        private MetadataItem _selectedMetadataItem;

        private string _selectedTypItem;

        private string _suchbegriff;

        private List<string> _typItems;

        public SearchViewModel()
        {
            TypItems = ComboBoxItems.Typ;

            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen);
        }

        public DelegateCommand CmdOeffnen { get; }

        public DelegateCommand CmdSuchen { get; }

        public DelegateCommand CmdReset { get; }

        public string Suchbegriff
        {
            get
            {
                return _suchbegriff;
            }

            set
            {
                SetProperty(ref _suchbegriff, value);
            }
        }

        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        public List<MetadataItem> FilteredMetadataItems
        {
            get
            {
                return _filteredMetadataItems;
            }

            set
            {
                SetProperty(ref _filteredMetadataItems, value);
            }
        }

        public MetadataItem SelectedMetadataItem
        {
            get
            {
                return _selectedMetadataItem;
            }

            set
            {
                if (SetProperty(ref _selectedMetadataItem, value))
                {
                    CmdOeffnen.RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnCanCmdOeffnen()
        {
            return SelectedMetadataItem != null;
        }

        private void OnCmdOeffnen()
        {
            // TODO: Add your Code here
        }

        private void OnCmdSuchen()
        {
            var metadataItems = new List<MetadataItem>();
            var metadataItemsXmlReferenz = new List<string>();
            var inputFolderPath = ConfigurationManager.AppSettings["RepositoryDir"];
            var allDirectories = Directory.GetDirectories(inputFolderPath);
            foreach (var directory in allDirectories)
            {
                foreach (var file in Directory.EnumerateFiles(directory, "*.xml"))
                {
                    metadataItemsXmlReferenz.Add(file);
                }
            }

            foreach (var xmlReferenz in metadataItemsXmlReferenz)
            {
                metadataItems.Add(new DataToXml().LesenMetadten(xmlReferenz));
            }

            if (SelectedTypItem == null)
            {
                FilteredMetadataItems = metadataItems;
                if (Suchbegriff != null)
                {
                    CmdSuchbegriffSuche(Suchbegriff.ToLower());
                }
            }
            else
            {
                FilteredMetadataItems = metadataItems.Where(m => m.Typ == SelectedTypItem).ToList();
                if (Suchbegriff != null)
                {
                    CmdSuchbegriffSuche(Suchbegriff.ToLower());
                }
            }

        }

        private void CmdSuchbegriffSuche(string suchbegriff)
        {
            FilteredMetadataItems = FilteredMetadataItems.Where(m => m.Bezeichnung.ToLower().Contains(suchbegriff) ||
                                                                     m.Stichwoerter != null && m.Stichwoerter.ToLower().Contains(suchbegriff)).ToList();
        }

        private void OnCmdReset()
        {
            Suchbegriff = String.Empty;
            SelectedTypItem = null;
            OnCmdSuchen();
        }
    }
}